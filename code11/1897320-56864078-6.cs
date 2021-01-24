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
                var points = ParseFromFile(
                    @"C:\Users\Student\Desktop\ConsoleApp1\ConsoleApp1\Data\TextFile.txt");
    
                RenderToFile(
                    @"C:\Users\Student\Desktop\Test.txt",
                    Merge(points).ToArray());
            }
    
            static void RenderToFile(string fileName, (double x, double y)[] points)
            {
                var formatProvider = new CultureInfo("en-US", false);
                var builder = new StringBuilder();
                foreach (var point in points)
                {
                    builder.Append(
                        $"X: {point.x.ToString(formatProvider)} Y:{point.y.ToString(formatProvider)}");
                }
                System.IO.File.WriteAllText(fileName, builder.ToString());
            }
    
            static (double x, double y)[] ParseFromFile(string fileName)
            {
                return Parse(System.IO.File.ReadAllText(fileName)).ToArray();
            }
    
            static IEnumerable<(double x, double y)> Merge((double x, double y)[] points)
            {
                points = points ?? throw new ArgumentNullException(nameof(points));
                if (points.Length == 0) yield break;
                var std = 100;
                var current = points[0];
                if (points.Length == 1)
                {
                    yield return current;
                    yield break;
                }
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
                var pattern = new Regex(@"^[Xx][:] (?<x>\d*([.]\d+)?) [Yy][:](?<y>\d*([.]\d+)?)$");
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
