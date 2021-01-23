            static void Main(string[] args)
            {
                string source = @"Cat, Animal, 2
    Dog, Animal, 3
    Luke, Human, 1
    Owl, Animal, 0";
    
                System.Text.RegularExpressions.Regex r = new System.Text.RegularExpressions.Regex(@", Animal, (\d+)");
                foreach (string line in source.Split(new string[] { Environment.NewLine },StringSplitOptions.RemoveEmptyEntries))
                {
    
                    System.Text.RegularExpressions.MatchCollection collection = r.Matches(line);
                    if (collection.Count == 1)
                    {
                        int val = -1;
                        int.TryParse(collection[0].Groups[1].Value, out val);
                        Console.WriteLine(line.Replace(val.ToString(), (val + 1).ToString()));
                    }
                    else
                    {
                        Console.WriteLine(line);
                    }
                }
            }
