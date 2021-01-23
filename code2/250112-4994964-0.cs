    using System.Text.RegularExpressions;
    namespace regexrep
    {
        class Program
        {
            static int Main(string[] args)
            {
                string fileText = System.IO.File.ReadAllText(args[0]);
                int matchCount = 0;
                string newText = Regex.Replace(fileText, args[1],
                    (match) =>
                    {
                        matchCount++;
                        return match.Result(args[2]);
                    });
                System.IO.File.WriteAllText(args[0], newText);
                return matchCount;
            }
        }
    }
