    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    class Program
    {
        static void Main(string[] args)
        {
            List<string> Files = new List<string>()
            {
                @"c:\abc\pqr\tmp\sample\b.txt",
                @"c:\abc\pqr\tmp\new2\c1.txt",
                @"c:\abc\pqr\tmp\b2.txt",
                @"c:\abc\pqr\tmp\b3.txt",
                @"c:\a.txt"
            };
            var MatchingChars =
                from len in Enumerable.Range(0, Files.Min(s => s.Length)).Reverse()
                let possibleMatch = Files.First().Substring(0, len)
                where Files.All(f => f.StartsWith(possibleMatch))
                select possibleMatch;
            var LongestDir = Path.GetDirectoryName(MatchingChars.First());
        }
    }
