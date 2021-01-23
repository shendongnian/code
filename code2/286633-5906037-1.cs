        public string GetResults(string text)
        {
            Regex wordRegex = new Regex(@"\W+");
            var scores = Dictionaries.Select(n => new
                {
                    Language = n.Key,
                    Score = wordRegex.Split(text)
                                     .Select(m => n.Value.getScore(m))
                                     .Sum()
                });
            int total = scores.Sum(n => n.Score);
            return string.Join(" ",scores.Select(n => "[" + n.Score * 100 / total + "% " + n.Language + "]");
        }
