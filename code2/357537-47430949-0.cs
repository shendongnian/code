         public string Script;
         string[] lines = Script.Split(new[] { '\r', '\n' });
                        for (int i = 0; i < lines.Length; i++)
                        {
                            lines[i] = a + lines[i] + b;
                            if (!lines[i].Equals("\"\"+"))
                            {
                                Console.WriteLine(lines[i]);
                                Result += lines[i]+"\n";
                            }
                        }
