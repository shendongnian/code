---------------------------
4     | hello java        |
---------------------------
5     | hello c#          |
---------------------------
These two are the ones not changing because they do not match the regex r"I love {anything} Code"
    static void Main(string[] args)
          {
            var stringsFromDB = new List<string> { "I love C# Code", "I love Java Code", "I love python Code", "hello java", "hello c#" };
            foreach (string record in stringsFromDB)
            {
                bool isMatches = Regex.IsMatch(record, "I love .+? Code");
                if (isMatches)
                {
                    Console.WriteLine("String matches");
                }
                else
                {
                    Console.WriteLine("String not matches");
                }
                string newString = Regex.Replace(record, "I love .+? Code", "I love Code", RegexOptions.IgnoreCase);
                Console.WriteLine(newString);
            }
            Console.Read();
        }
