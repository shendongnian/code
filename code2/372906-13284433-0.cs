           string SentenceToCheck = "Hi, I can wonder this situation where I can do best";
          //Here I am giving several way to find this
            //Using Regular Experession
            int HowMany = Regex.Split(SentenceToCheck, "a", RegexOptions.IgnoreCase).Length - 1;
            int i = Regex.Matches(SentenceToCheck, "a").Count;
            // Simple way
            int Count = SentenceToCheck.Length - SentenceToCheck.Replace("a", "").Length;
            //Linq
            var _lamdaCount = SentenceToCheck.ToCharArray().Where(t => t.ToString() != string.Empty)
                .Select(t => t.ToString().ToUpper().Equals("A")).Count();
         
            int a =lamdaCount.Count;
            var _linqCount = from g in SentenceToCheck.ToCharArray()
                             where g.ToString().Equals("a")
                             select g;
            int a = _linqCount.Count();
