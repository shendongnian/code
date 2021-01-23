            double tan = height*1.00/width;
            double angle = (180.0 * Math.Atan(tan) / Math.PI);
            var bitmap = new System.Drawing.Bitmap(image, width, height);
            var g = System.Drawing.Graphics.FromImage(bitmap);
            int fontsize = 26; // starting guess
            Font font = null;
            System.Drawing.SizeF size;
            Func<SizeF,double> angledWidth = new Func<SizeF,double>( (x) =>
                {
                    double z = x.Height * Math.Sin(angle) +
                    x.Width * Math.Cos(angle);
                    return z;
                });
            // enlarge for width
            do
            {
                fontsize+=2;
                if (font != null) font.Dispose();
                font = new Font("Arial", fontsize, System.Drawing.FontStyle.Bold);
                size = g.MeasureString(_text, font);
            }
            while (angledWidth(size)/0.85 < width);
