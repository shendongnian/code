        string latestversion = args[0];
        using (StreamReader sr = new StreamReader("C:\\Work\\list.txt"))
        using (StreamWriter sw = new StreamWriter("C:\\Work\\otherFile.txt"))
        {
                // loop by lines - for big files
                string line = sr.ReadLine();
                while (line.Length > 0)
                {
                    if (line.IndexOf(latestversion) > -1)
                        sw.Write("1");
                    else
                        sw.Write("0");
                    line = sr.ReadLine();
                }
                // other solution - for small files
                var fileContents = sr.ReadToEnd();
                {
                    if (fileContents.IndexOf(latestversion) > -1)
                        sw.Write("1");
                    else
                        sw.Write("0");
                }
        }   
