c#
//Sharing is caring: Communism goes here
        private System.Windows.Forms.Timer timtim;
        int rand0;
        PictureBox Rooskie = new PictureBox();
        Label test = new Label();
        Random rando = new Random();
        List<int> duplicheck = new List<int>();
        private void boopthesnoot(object sender, EventArgs e)
        {
        dingding:
            //Hell yeah, random numbers here
            rand0 = rando.Next(1, 26);
            /*string combowombo = string.Join(", ", duplicheck.ToArray());
            test.Text = combowombo;
            test.Font = new Font("Calibri", 20);
            Controls.Add(test);
            test.Location = new Point(0, 200);
            test.Height = 1000;
            test.Width = 1000;*/
            if(duplicheck.Contains(rand0))
            {
                goto dingding;
            }
            else
            {
                GOBUTTON.Hide();
                pictureBox1.Hide();
                pictureBox2.Hide();
                //Fuckin image code goes here my dood
                Rooskie.Width = 1160;
                Rooskie.Height = 620;
                Bitmap image = new Bitmap(WindowsFormsApp1.Properties.Resources._1);
                Rooskie.Dock = DockStyle.Fill;
                Rooskie.Image = (Image)image;
                Controls.Add(Rooskie);
                Rooskie.SizeMode = PictureBoxSizeMode.CenterImage;
                //Aww shit, it's that timer time
                timtim = new System.Windows.Forms.Timer();
                timtim.Tick += new EventHandler(clockfinish);
                timtim.Interval = 3000;
                timtim.Start();
                duplicheck.Add(rand0);
                if (duplicheck.Count == 25)
                {
                    duplicheck = new List<int>();
                }
            }
            
        }
