     Bitmap bmp =new Bitmap(panel1.Width,panel1.Height);
        panel1.DrawToBitmap(bmp, panel1.Bounds);
        System.IO.MemoryStream ms = new System.IO.MemoryStream();
        bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
        byte[] result = new byte[ms.Length];
        ms.Seek(0,System.IO.SeekOrigin.Begin);
        ms.Read(result, 0, result.Length);
