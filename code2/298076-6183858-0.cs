        string latestversion = args[0];
        // create reader & open file
        using (StreamReader sr = new StreamReader("C:\\Work\\list.txt"))
        using (StreamWriter sw = new StreamWriter("C:\\Work\\otherFile.txt"))
        {
                string line = sr.ReadLine();
                while (line.Length > 0)
                {
                    if (line.IndexOf(latestversion) > -1)
                        sw.Write("1");
                    else
                        sw.Write("0");
                    line = sr.ReadLine();
                }
        }   
