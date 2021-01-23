        public void Method1()
        {
            Image img = Image.FromFile(fileName);
            Bitmap bmp = img as Bitmap;
            Graphics g = Graphics.FromImage(bmp);
            Bitmap bmpNew = new Bitmap(bmp);
            g.DrawImage(bmpNew, new Point(0, 0));
            g.Dispose();
            bmp.Dispose();
            img.Dispose();
 
            //code to manipulate bmpNew goes here.
 
            bmpNew.Save(fileName);
        }
