        for (int i = 0; i < 3; i++)
        {
            for (int y = 0; y < 3; y++)
            {
                Rectangle r = new Rectangle(i*(pictureBox1.Image.Width / 3), 
                                            y*(pictureBox1.Image.Height / 3), 
                                            pictureBox1.Image.Width / 3, 
                                            pictureBox1.Image.Height / 3);
                
                g.DrawRectangle(pen,r );
                list.Add(cropImage(pictureBox1.Image, r));
            }
        }
