            using (var writer = File.CreateText("output.txt"))
            {
                foreach (string line in File.ReadAllLines("input.txt"))
                {
                    var match = Regex.Match(line, "Stuff.*?\\.rar");
                    if (match.Success)
                        writer.WriteLine(match.Value);
                }
            }
