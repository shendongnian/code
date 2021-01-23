    private void Form1_Load(object sender, EventArgs e)
            {
                int x = 0;
                int y = 0;
    
                for (int i = 0; i < 81; i++)
                {
                    PictureBox p = new PictureBox();
                    p.BorderStyle = BorderStyle.Fixed3D;
                    p.Height = 80;
                    p.Width = 80;
                    p.Location = new Point(x, y);
    
                    x += 85;
    
                    if (x > 425)
                    {
                        x = 0;
                        y += 85;
                    }
    
                    this.Controls.Add(p);
                }
    
            }
