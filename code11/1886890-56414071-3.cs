    string[] lines = File.ReadAllLines(INILoc);
    using (StreamWriter writer = new StreamWriter(INILoc)) // https://docs.microsoft.com/en-us/dotnet/standard/io/how-to-write-text-to-a-file
    {
                bool containsSearchResul = false;
                foreach (string line in lines)
                {
                    if (!containsSearchResul)
                    {
                        writer.Write(INILoc, string.Empty);
                    }
                    if (line.Contains("[names]"))
                    {
                        containsSearchResul = true;
                    }
                }
    }
