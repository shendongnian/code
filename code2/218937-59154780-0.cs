    using (StreamReader source = new StreamReader(sourceFileName))
            {
                using (StreamWriter sw = new StreamWriter(newFileName))
                {
                    do
                    {
    
                        line = source.ReadLine();
    
                        if (source.Peek() > -1)
                        {
                            sw.WriteLine(line);
                        }
                        else
                        {
                            File.AppendAllText("RemovedLastLine.txt", line);
                        }
                       
                    }
                    while (line != null);
                }
            }
