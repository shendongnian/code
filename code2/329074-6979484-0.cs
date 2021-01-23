            int x = 0;
            int y = 0;
            int width = 0;
            int height = 0;
            Point[] pesource = null;
            GraphicsPath gpdest = new GraphicsPath();
            source = new Bitmap(Image.FromFile(@"IMAGEPATH"));
            //Your polygon
            pesource = new Point[]
            {
                new Point(10,100),
                new Point(30,150),
                new Point(40,170),
                new Point(60,120),
                new Point(70,250),
                new Point(40,300),
                new Point(10,250),
                new Point(30,150)
            };
            //Determine the destination size/position
            x = source.Width;
            y = source.Height;
            foreach (var p in pesource)
            {
                if (p.X < x)
                    x = p.X;
                if (p.X > width)
                    width = p.X;
                if (p.Y < y)
                    y = p.Y;
                if (p.Y > height)
                    height = p.Y;
            }
            height = height - y;
            width = width - x;
            gpdest.AddPolygon(pesource);
            Matrix m = new Matrix(1, 0, 0, 1, -x, -y);
            gpdest.Transform(m);
            //Create the Bitmap
            clipped = new Bitmap(width, height);
            //Draw on the Bitmap
            using (Graphics g = Graphics.FromImage(clipped))
            {
                GraphicsPath gpgdi = new GraphicsPath();
                g.SetClip(gpdest);
                g.DrawImage(source, -x, -y);
            }
