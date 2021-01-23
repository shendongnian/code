    using (StreamWriter writer = new StreamWriter("out.out")) // file to write to
                {
                    using (StreamReader reader = new StreamReader("input.dat")) //file to read from
                    {
                        Regex regex = new Regex(@"^([A-Z]{1})([0-9]{1}),0,([A-Z0-9_]+)$");
                        string line;
                        while (reader.Peek() > 0)
                        {
                            line = reader.ReadLine();
                            if (regex.IsMatch(line))
                            {
                                writer.WriteLine(string.Format("{0}0{1} {2}", regex.Match(line).Groups[1], regex.Match(line).Groups[2], regex.Match(line).Groups[3]));
                            }
                        }
    
                    }
                }
