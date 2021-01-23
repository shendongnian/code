    System.IO.MemoryStream ms = new System.IO.MemoryStream();
            System.IO.FileStream file = new System.IO.FileStream("file.txt", System.IO.FileMode.Create, System.IO.FileAccess.Read);
            byte[] bytes = new byte[file.Length];
            file.Read(bytes, 0, (int)file.Length);
            ms.Write(bytes, 0, (int)file.Length);
            file.Close();
            ms.Close();
