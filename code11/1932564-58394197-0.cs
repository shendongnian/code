      using System.Linq; 
      using System.Text.RegularExpressions;
      ....
      string coordinate = "20, 10   10, 20";
      Regex regex = new Regex(@"(?<x>-?[0-9]+),\s*(?<y>-?[0-9]+)");
      var points = regex
        .Matches(coordinate)
        .Cast<Match>()
         // I've put Point but you may want different class / struct
        .Select(match => new Point(int.Parse(match.Groups["x"].Value), 
                                   int.Parse(match.Groups["y"].Value)))
        .ToArray(); // Let's materialize into an array
      // int x1 = points[0].X;
      // int y1 = points[0].Y;
      // int x2 = points[1].X;
      // int y2 = points[1].Y;
      Console.WriteLine(Environment.NewLine, points);
