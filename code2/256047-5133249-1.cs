    static void Main(string[] args)
        {
            string path = @"c:\test.txt";
            string t = File.ReadAllText(path);
            string pattern1 = @"OperatorID=(.+?),,Name=(.+?),(.+?),Enablestatus";
            Regex rgx = new Regex(pattern1);
            //Removes all tabbed spaces.
            t = t.Replace("\t", "");
            //Removes any new lines.
            t = t.Replace("\n", ",");
            //Removes blank spaces.
            t = t.Replace(" ", "");
            //Removes the Underscore.
            t = t.Replace("_", "");
            t = t.Replace("\r", "");
            MatchCollection matches = rgx.Matches(t);
            List<string[]> test = new List<string[]>();
            foreach (var match in matches)
            {
                string[] newString = match.ToString().Split(new string[] { @"OperatorID=", @",,Name=", @",Activeprofile=", @",Enablestatus",  }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 3 ; i <= newString.Length; i++)
                {
                    test.Add(new string[] { newString[0], newString[1], newString[i - 1] });
                }
            }
            foreach (var line in test)
            {
                Console.WriteLine("ID: {0}\nName: {1}\nActive Profile: {2}\n", line[0], line[1], line[2]);
            }
            Console.ReadKey();
