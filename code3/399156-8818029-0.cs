    private void Form_Load(object sender, EventArgs e)
            {
                moveTimer.Interval = 1000;
                moveTimer.Tick += new EventHandler(moveTimer_Tick);
                moveTimer.Start();
            }
        private void moveTimer_Tick(object sender, System.EventArgs e)
                {
                   string[] images = Directory.GetFiles(@"C:\Dir", "*.jpg");  
                   image = Image.FromFile(images[counter]);
                   pictureBox.Width = image.Width;
                   pictureBox.Height = image.Height;
                   pictureBox.Image = image;
                   
        
                    // Move Image to new location
                    pictureBox.Left = rand.Next(Math.Max(0, Bounds.Width - pictureBox.Width));
                    pictureBox.Top = rand.Next(Math.Max(0, Bounds.Height - pictureBox.Height));
        
                    if (counter < images.Count - 1)
                    {
                        counter = counter + 1;
                    }
                    else
                    {
                        counter = 0;
                    }
                }
