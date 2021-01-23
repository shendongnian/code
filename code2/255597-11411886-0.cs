             this.Opacity = 0;
            Rectangle bounds = Screen.GetBounds(Point.Empty);
            // create the bitmap to copy the screen shot to
            Bitmap bitmap = new Bitmap(bounds.Width, bounds.Height);
            // now copy the screen image to the graphics device from the bitmap
            using (Graphics gr = Graphics.FromImage(bitmap))
            {
               
                gr.CopyFromScreen(Point.Empty, Point.Empty, bounds.Size);          
            }
            this.Opacity = 100;
