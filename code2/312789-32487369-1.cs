        private void Truncate(readPath)     // to clear contents of file, copy, and note last time it was cleared and copied
        {
            if (!File.Exists(readPath))    // create the new file for storing old entries
            {
                string readFile = readPath + ".txt";
                string writeFile = readPath + DateTime.Now.ToString("_dd-MM-yyyy_hh-mm") + ".txt"; // you can add all the way down to milliseconds if your system runs fast enough
                using (FileStream fs = new FileStream(writeFile, FileMode.OpenOrCreate, FileAccess.Write))
                {
                    using (StreamWriter write = new StreamWriter(fs))
                    using (StreamReader file = new StreamReader(readFile))
                    {
                        write.WriteLine(string.Format(textA, DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt")));
                        string line;
                        var sb = new StringBuilder();
                        while ((line = file.ReadLine()) != null)
                        {
                            line = line.Replace("\0", ""); // removes nonsense bits from stream
                            sb.AppendLine(line);
                        }
                        write.WriteLine(sb.ToString());
                        string textB = "{0} : Copied Source";
                        write.WriteLine(string.Format(textB, DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt")));
                    }
                }
                string str = string.Format("{0} : Truncated Contents", DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt"));
                using (StreamWriter truncate = new StreamWriter(readFile))
                {
                    truncate.WriteLine(str); // truncates and leaves the message with DateTime stamp
                }
            }
        }
