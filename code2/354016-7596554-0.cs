           using (FileStream fs = new FileStream(@"file.txt", FileMode.Open, FileAccess.Read))
            {
                fs.Seek(100, SeekOrigin.Begin);
                byte[] b = new byte[fs.Length - 100];
                fs.Read(b, 0, (int)(fs.Length - 100));
                string s = System.Text.Encoding.UTF8.GetString(b);
            }
