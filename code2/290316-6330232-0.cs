        private void CalculateZoomAndPadding()
        {
            Double imageAspect = (Double)pictureBox1.Image.Width / (Double)pictureBox1.Image.Height;
            Double pbAspect = (Double)pictureBox1.Width / (Double)pictureBox1.Height;
            Boolean heightRestricted = imageAspect < pbAspect;
            hPadding = 0;
            vPadding = 0;
            if (heightRestricted)
            {
                zoom = (Double)pictureBox1.Height / (Double)pictureBox1.Image.Height;
                Double imageWidth = (Double)pictureBox1.Image.Width * zoom;
                hPadding = (Double)(pictureBox1.Width - imageWidth) / 2d;
            }
            else
            {
                zoom = (Double)pictureBox1.Width / (Double)pictureBox1.Image.Width;
                Double imageHeight = (Double)pictureBox1.Image.Height * zoom;
                vPadding = (Double)(pictureBox1.Height - imageHeight) / 2d;
            }
        }
