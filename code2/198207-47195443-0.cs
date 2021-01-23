        static IEnumerable<string> TailFrom(string file)
        {
            using (var reader = File.OpenText(file))
            {
                while (true) 
                {
                    string line = reader.ReadLine();
                    if (reader.BaseStream.Length < reader.BaseStream.Position) 
                        reader.BaseStream.Seek(0, SeekOrigin.Begin);
                    if (line != null) yield return line;
                    else Thread.Sleep(500);
                }
            }
        }
