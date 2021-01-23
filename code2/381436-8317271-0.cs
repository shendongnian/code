                Bitmap blank = new Bitmap(DrawArea.Width, DrawArea.Height);
                Graphics g = Graphics.FromImage(blank);
                g.Clear(Color.White);
                g.DrawImage(DrawArea, 0, 0, DrawArea.Width, DrawArea.Height);
    
                Bitmap tempImage = new Bitmap(blank);
                blank.Dispose();
                DrawArea.Dispose();
    
                if (extension == ".jpeg")
                    tempImage.Save(fileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                else
                    tempImage.Save(fileName, System.Drawing.Imaging.ImageFormat.Bmp);
    
                DrawArea = new Bitmap(tempImage);
                pictureBox1.Image = DrawArea;
    
                tempImage.Dispose();
