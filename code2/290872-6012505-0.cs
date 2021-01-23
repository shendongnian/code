            using (var file = File.Open("p:\\t.txt", FileMode.Open))
            {
                int b;
                while ((b = file.ReadByte()) >= 0)
                {
                    string s = b.ToString("X");
                    if (s.Length < 2)
                        s = "0" + s;
                }
            }
