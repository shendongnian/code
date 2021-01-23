            string path = null;//path of file
            byte[] bytes_to_write = null;
            System.IO.File.WriteAllText(path, string.Empty);
            System.IO.FileStream str = new System.IO.FileStream(path, System.IO.FileMode.Open, System.IO.FileAccess.Write, System.IO.FileShare.Read);
            str.Write(bytes_to_write, 0, bytes_to_write.Length);
