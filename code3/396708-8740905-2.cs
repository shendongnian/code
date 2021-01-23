    public static Point[] Parse(string minilanguage)
            {
                // leave just M's
                minilanguage = minilanguage.ToUpper().Replace("M", string.Empty);
                
                // remove spaces
                minilanguage = minilanguage
                    .ToCharArray()
                    .Where(t => t != ' ')
                    .Select(t => t.ToString())
                    .Aggregate((f, s) => f + s).ToString();
                
    
                return minilanguage
                    .Split("L".ToCharArray())
                    .Select(t => Point.Parse(t))
                    .ToArray();
            }
