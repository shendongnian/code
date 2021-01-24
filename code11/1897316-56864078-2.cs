    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Dynamic;
    using System.Globalization;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Text.RegularExpressions;
    
    namespace ConsoleApp1
    {
        class Program
        {
            static void Main(string[] args)
            {
                // read from file: var points = Parse(File.ReadAllText("myFileName"));
                var points = Parse(@"
    Recorded Data 1
    
    X: 1081.02409791506 Y:136.538121516361
    Data collected at 208786.9115
    
    
    Recorded Data 2
    
    X: 1082.82841293328 Y:139.344405668078
    Data collected at 208810.0446
    
    Recorded Data 4
    
    X: 1525.397051187 Y:1163.1786031393
    Data collected at 245756.8823
    
    Recorded Data 5
    
    X: 1524.98201445054 Y:1166.38589429581
    Data collected at 245769.489
    
    Recorded Data 6
    
    X: 509.002294087998 Y:913.213486303154
    Data collected at 277906.6251
    
    Recorded Data 7
    
    X: 479.826998339658 Y:902.689393940613
    Data collected at 277912.9958").ToArray();
                var results = Merge(points);
    
                // store to file..
                foreach (var point in results)
                {
                    Console.WriteLine(point);
                }
    
                Console.ReadKey();
            }
    
            static IEnumerable<(double x, double y)> Merge((double x, double y)[] points)
            {
                points = points ?? throw new ArgumentNullException(nameof(points));
                if (points.Length == 0) yield break;
                var std = 100;
                var current = points[0];
                for (var i = 1; i < points.Length; i++)
                {
                    var dx = Math.Abs(points[i].x - current.x);
                    var dy = Math.Abs(points[i].y - current.y);
    
                    if (dx <= std && dy <= std)
                    {
                        continue;
                    }
    
                    yield return current;
                    current = points[i];
                }
                yield return current;
            }
    
            static IEnumerable<(double x, double y)> Parse(string raw)
            {
                var formatProvider = new CultureInfo("en-US", false);
                var pattern = new Regex(@"^[Xx][:] (?<x>\d*([.]\d+)?) [Yy][:](?<y>\d*([.]\d+))$");
                raw = raw ?? throw new ArgumentNullException(nameof(raw));
                foreach (var line in raw.Split(
                    Environment.NewLine, StringSplitOptions.RemoveEmptyEntries).Where(
                    line => line.ToLowerInvariant().StartsWith("x")))
                {
                    var match = pattern.Match(line);
                    var xToken = match.Groups["x"].Value.Trim();
                    var yToken = match.Groups["y"].Value.Trim();
                    var x = double.Parse(xToken, formatProvider);
                    var y = double.Parse(yToken, formatProvider);
                    yield return (x: x, y: y);
                }
            }
        }
    }
