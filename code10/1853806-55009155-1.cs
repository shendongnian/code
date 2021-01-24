     private const string MyPattern = @"\[\s*(?<x>\d{1,3})\s+(?<y>\d{1,3})\s+(?<r>\d{1,3})\]";
     private static readonly Regex MyRegex = new Regex(MyPattern);
     public static CircleCordinates ParseIt()
     {
         var firstSplit = StringToParse.Split(',');
         var path = firstSplit[0].Trim();
         var data = firstSplit[1];
         var matches = MyRegex.Matches(data);
         var circle = new List<Tuple<double, double, double>>();
         foreach (var match in matches.Cast<Match>())
         {
             var tuple = new Tuple<double, double, double>(
                 double.Parse(match.Groups["x"].ToString()),
                 double.Parse(match.Groups["y"].ToString()),
                 double.Parse(match.Groups["r"].ToString()));
             circle.Add(tuple);
         }
         var result = new CircleCordinates {image = path, circle = circle};
         return result;
     }
