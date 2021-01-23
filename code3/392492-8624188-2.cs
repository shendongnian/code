    FileStream file = new FileStream("file.bin", FileMode.Create, System.IO.FileAccess.Write);
    byte[] bytes = new byte[ms.Length];
    ms.Read(bytes, 0, (int)ms.Length);
    file.Write(bytes, 0, bytes.Length);
    file.Close();
    ms.Close();
