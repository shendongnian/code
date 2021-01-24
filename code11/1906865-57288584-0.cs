using (var reader = new StreamReader(sourcePath))
            {
                using (var writer = new StreamWriter(destiPath))
                {
                    String line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        var list = line.Split(',');
                        if (list.Length > 2 && !string.IsNullOrEmpty(list[2].Trim(' ','\"')))
                        {
                            writer.WriteLine(line);
                        }
                    }
                }
            }
