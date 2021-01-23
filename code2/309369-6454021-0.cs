    var result = File.ReadAllLines("inFile").SelectMany(line =>
                    {
                        var ar = line.Split(" ".ToCharArray());
                        var num = int.Parse(ar[0].Split(":".ToCharArray())[0]);
                        return ar.Skip(1).Select(s => new Tuple<string, int>(s, num));
                    }).GroupBy(t => t.Item1).OrderByDescending(g => g.Count())
                    .Select(g => g.Key + ": " + g.Select(t => t.Item2.ToString()).Aggregate( (a,b) => a + " " + b));
                File.WriteAllLines("outFile", result);
