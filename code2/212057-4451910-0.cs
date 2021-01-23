        public static string Contract(this string e, int maxLength)
        {
            if(e == null) return e;
            int questionMarkIndex = e.IndexOf('?');
            if (questionMarkIndex == -1)
                questionMarkIndex = e.Length - 1;
            int lastPeriodIndex = e.LastIndexOf('.', questionMarkIndex, 0);
            string question = e.Substring(lastPeriodIndex != -1 ? lastPeriodIndex : 0, questionMarkIndex + 1).Trim();
            var punctuation =
                new [] {",", ".", "!", ";", ":", "/", "...", "...,", "-,", "(", ")", "{", "}", "[", "]","'","\""};
            question = punctuation.Aggregate(question, (current, t) => current.Replace(t, ""));
            IDictionary<string, bool> words = question.Split(' ').ToDictionary(x => x, x => false);
            //return words[0] + "..." + words[words.Length - 1];
            string mash = string.Empty;
            while (words.Any(x => !x.Value) && mash.Length < maxLength)
            {
                int maxWordLength = words.Where(x => !x.Value).Max(x => x.Key.Length);
                var pair = words.Where(x => !x.Value).Last(x => x.Key.Length == maxWordLength);
                words.Remove(pair);
                words.Add(new KeyValuePair<string, bool>(pair.Key, true));
                mash = string.Join("", words.Where(x => x.Value)
                                           .Select(x => x.Key.Capitalize())
                                           .ToArray()
                    );
            }
            return mash;
        }
