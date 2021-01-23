            //grab all possible pairings in one data structure
            List<KeyValuePair<string, string>> pairs = new List<KeyValuePair<string, string>>();
            string[] list = { "acks", "top", "cat", "gr", "by", "bar", "lap", "st", "ely", "ades" };
            foreach (string first in list)
            {
                foreach (string second in list)
                {
                    pairs.Add(new KeyValuePair<string, string>(first, second));
                }
            }
            //test each pairing for length and whatever else you want really
            List<string> sixLetterWords = new List<string>();
            foreach (KeyValuePair<string, string> pair in pairs)
            {
                string testWord = pair.Key + pair.Value;
                if (testWord.Length == 6)
                {
                    sixLetterWords.Add(testWord);
                }
            }
