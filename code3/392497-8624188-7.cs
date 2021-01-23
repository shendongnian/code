        using (MemoryStream ms = new MemoryStream()) {
          using (FileStream file = new FileStream("file.bin", FileMode.Open, FileAccess.Read)) {
            byte[] bytes = new byte[file.Length];
            file.Read(bytes, 0, (int)file.Length);
            ms.Write(bytes, 0, (int)file.Length);
          }
        }
