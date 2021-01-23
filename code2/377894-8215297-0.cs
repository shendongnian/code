        try
        {
            using (StreamReader sr = new StreamReader(@"C:\bigfile.txt"))
            {
                using (StreamWriter sw = new StreamWriter(@"C:\bigfilelinebreak.txt"))
                {
                    char [] buf = new char[40];
                    int read = sr.ReadBlock (buf, 0, 40);
                    while (read != 0)
                    {
                        sw.Write(buf, 0, read);
                        sw.WriteLine();
                        read = sr.ReadBlock (buf, 0, 40);
                    }
                }
            }
        }
