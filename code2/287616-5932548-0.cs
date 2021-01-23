            Dictionary<Colors,Func<int,int>> d = new Dictionary<Colors, Func<int, int>>();
            d.Add(Colors.Red, (x) => x+1);
            d.Add(Colors.Blue, (x) => x+1);
            d.Add(Colors.Green, (x) => x+1);
            foreach (Colors color in Enum.GetValues(typeof(Colors)))
            {
                if(!d.ContainsKey(color))
                {
                    throw new Exception("Poor color " + color + " ignored");
                }
            }
