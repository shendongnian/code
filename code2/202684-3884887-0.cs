            Bitmap b = Bitmap.FromFile(filename); // this is 300x300
            Image img = new Bitmap(500, 500);
            using(Graphics g = Graphics.FromImage(img))
            {
                g.DrawImage(b, 0, 0, 500, 500);
            }
