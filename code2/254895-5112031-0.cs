    StreamReader Reader = new StreamReader(MainFileName);
                char c = Convert.ToChar(@"/");
                Char[] splitChar = { c, c };
                String Line;
                while (!Reader.EndOfStream)
                {
                    Line = Reader.ReadLine();
                    String[] Parts;
                    Parts = Line.Split(splitChar);
                    foreach (string s in Parts)
                    {
                        Console.WriteLine(s);
                    }
                }
                Reader.Close();
                Console.WriteLine("Done");
