    MemoryStream ms = new MemoryStream();
    Bitmap bmp = new Bitmap(panel1.Width, panel1.Height);
    panel1.DrawToBitmap(bmp, panel1.Bounds);
    bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg); // here you can change the Image format
    byte[] Pic_arr = new byte[ms.Length];
    ms.Position = 0;
    ms.Read(Pic_arr, 0, Pic_arr.Length);
    ms.Close();
