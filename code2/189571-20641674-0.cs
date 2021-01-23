        byte[] GetFile(string s)
        {
            byte[] data;
            using (System.IO.FileStream fs = System.IO.File.OpenRead(s))
            {
                data = new byte[fs.Length];
                int br = fs.Read(data, 0, data.Length);
                if (br != fs.Length)
                    throw new System.IO.IOException(s);
            }
            return data;
        }
