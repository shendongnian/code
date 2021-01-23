        CultureInfo c = new CultureInfo("en-US");
        private List<string> Capitalize(List<string> words, bool isup)
        {
            var textInfo = c.TextInfo;
            for (int i = 0; i < words.Count; i++)
            {
                var str = words[i];
                words[i] = isup ? textInfo.ToTitleCase(str) : str.ToLower();
            }
            return words;
        }
        
