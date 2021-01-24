                        List<string> ignores = new List<string>(){ "MR", "MS", "MRS", "DR", "PROF" };
            ignores = ignores.Select(x => @"\s" + x).ToList();
            string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            foreach (char letter in alphabet.ToCharArray())
            {
                ignores.Add(@"\s" + letter);
            }
            string test = "This is a test for Prof. Plum. Here is a test for Ms. White. This is A. Test. Welcome to GMR. Next Line.";
            string regexPattern = $@"(?<!{string.Join("|", ignores)})\.\s";
            string[] results = Regex.Split(test, regexPattern, RegexOptions.IgnoreCase);
    
