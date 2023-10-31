using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace minecky
{
    public class Policko : Label
    {
        public bool BOMBA;
        int x;
        int y;

        public int Sousedi(Policko[,] pole)
        {
            int sousedi = 0;

            x = int.Parse(this.Name.Split('_')[0]);
            y = int.Parse(this.Name.Split('_')[1]);


            

            for(int i = -1; i < 2; i++)
            {
                for(int j = -1; j < 2; j++)
                {
                    if (pole[x + i, y + j].BOMBA == true && !(i==0 && j == 0))
                    {
                        sousedi += 1;
                    }
                }
            }

            return sousedi;
        }
    }

    public partial class Form1 : Form
    {
        Policko[,] pole;

        public Form1()
        {
            InitializeComponent();
            

            pole = new Policko[10, 10];

            for (int i = 0; i < pole.GetLength(0); i++)
            {
                for (int j = 0; j < pole.GetLength(1); j++)
                {
                    pole[i, j] = new Policko();
                    this.Controls.Add(pole[i,j]);

                    pole[i, j].Location = new Point(25 * i, 25 * j);
                    pole[i, j].Name = i +"_"+ j;
                    pole[i, j].Size = new Size(25, 25);
                    pole[i, j].TabIndex = 0;
                    pole[i, j].Click += new EventHandler(velkyTresk);
                    pole[i,j].BorderStyle = BorderStyle.FixedSingle;
                     
                }

            }

            pole[5, 5].BOMBA = true;

            InitializeComponent();

           

        }

        private void Konec()
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void velkyTresk (object sender, EventArgs e)
        {
            Policko sender2 = (Policko)sender;

            if (sender2.BOMBA == true)
            {
                Konec();
            }
            else
            {
                sender2.Text = sender2.Sousedi(pole).ToString();
            }
        }
    }
}
