            Bitmap bmp = new Bitmap(1000,1000);
            
            using (Graphics g = Graphics.FromImage(bmp))
            {
              string s = "This string will be wrapped in the output rectangle";
              RectangleF rectf = new RectangleF (10, 100, 200, 200);
              
              g.DrawString(s, DefaultFont, Brushes.Red, rectf);
              this.BackgroundImage = bmp; //For testing purposes set the form's background to the image
              
            }
