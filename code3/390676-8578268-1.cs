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
                where Files.All(f => f.StartsWith(Files.First().Substring(0, len)))
                select Files.First().Substring(0, len);
            var LongestDir = Path.GetDirectoryName(MatchingChars.First());
        }
    }
