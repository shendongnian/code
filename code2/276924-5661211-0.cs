    namespace ConsoleApplication6
    {
        using System;
        using System.Collections.Generic;
        using System.IO;
        using System.Text.RegularExpressions;
    
        class Program
        {
            static void Main(string[] args)
            {
                string filename = @"c:\test.txt";
    
                // Because you're working with a small file, we'll just read all the lines into memory
                List<LineData> processedLines = new List<LineData>();
                foreach (var line in File.ReadAllLines(filename))
                {
                    processedLines.Add(new LineData(line));
                }
    
                // Write out the line data to the console to prove that it has been read
                foreach (var processedLine in processedLines)
                {
                    Console.WriteLine(
                        "{0},{1},{2},{3},{4},{5}", 
                        processedLine.Column1, 
                        processedLine.Column2,
                        processedLine.Column3,
                        processedLine.Column4,
                        processedLine.Column5,
                        processedLine.Column6);
                }
            }
        }
    
        public class LineData
        {
            public LineData(string line)
            {
                // Regex basically means find two digits ("Prefix") followed by 3 digits ("Value")
                Regex regex = new Regex(@"(?<Prefix>\d{2})(?<Value>\d{3})");
                var lineMatches = regex.Matches(line);
                if (lineMatches.Count != 6)
                {
                    // You should really be throwing your own exception type...
                    throw new Exception("Expected 6 columns!");
                }
    
                this.Column1 = this.ExtractMatchData(lineMatches[0]);
                this.Column2 = this.ExtractMatchData(lineMatches[1]);
                this.Column3 = this.ExtractMatchData(lineMatches[2]);
                this.Column4 = this.ExtractMatchData(lineMatches[3]);
                this.Column5 = this.ExtractMatchData(lineMatches[4]);
                this.Column6 = this.ExtractMatchData(lineMatches[5]);
            }
    
            private string ExtractMatchData(Match match)
            {
                return match.Groups["Value"].Value;
            }
    
            public string Column1 { get; set; }
            public string Column2 { get; set; }
            public string Column3 { get; set; }
            public string Column4 { get; set; }
            public string Column5 { get; set; }
            public string Column6 { get; set; }
        }
    }
