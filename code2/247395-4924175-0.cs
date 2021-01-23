                public void ReadJustNumbers()
                {
                    Regex r = new Regex(@"\d+"); 
                    using (var sr = new StreamReader("xxx"))
                    {
                        string line;
                        while (null != (line=sr.ReadLine()))
                        {
                            foreach (Match m in r.Matches(line))
                            {
                                Console.WriteLine(m.Value);
                            }
                        }
                    }
                }
