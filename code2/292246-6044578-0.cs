            try
            {
                //Getting The Image From The System
                OpenFileDialog open = new OpenFileDialog();
                open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
                if (open.ShowDialog() == DialogResult.OK)
                {
                    System.IO.FileInfo file = new System.IO.FileInfo(open.FileName);
                    Bitmap img = new Bitmap(open.FileName);
                    if (img.Width < MAX_WIDTH &&
                        img.Height < MAX_HEIGHT &&
                        file.Length < MAX_SIZE)
                        pictureBox2.Image = img;
                }
            }
            catch (Exception)
            {
                throw new ApplicationException("Failed loading image");
            }
