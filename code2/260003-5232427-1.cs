    using (Bitmap bmpToSave = new Bitmap(1000, 500)) {
        using (Graphics g = Graphics.FromImage(bmpToSave)) {
            g.DrawImage(bmp, 0, 0, 1000, 500);
        }
        bmpToSave.Save(@"bitmap.bmp");
    }
