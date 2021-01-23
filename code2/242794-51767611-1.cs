    picbpp.Save("pic.bmp", ImageFormat.Bmp);
    string path = "pic.bmp";
    FileStream fs = File.Open(path, FileMode.Open, FileAccess.Write, FileShare.None);
    // Change biSizeimage field manually.
    Byte[] info = new byte[] {0x10,0x59};
    fs.Seek(34, SeekOrigin.Begin);
    fs.Write(info, 0, info.Length);
    fs.Close();
