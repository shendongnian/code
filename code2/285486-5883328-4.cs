    class TextLinker : IComparer<string>
    {
        private SortedDictionary<string, string> phrasesToUrls;
    
        public TextLinker()
        {
            // Pass self as IComparer to sort dictionary using Compare method.
            phrasesToUrls = new SortedDictionary<string, string>(this);
        }
    
        public void AddLink(string phrase, string URL)
        {
            phrasesToUrls.Add(phrase, URL);
        }
    
        public string Link(string text)
        {
            // phase 1: replace phrases to be linked with unique placeholders
            Dictionary<string, string> placeholdersToLinks =
                new Dictionary<string, string>();
            foreach (KeyValuePair<string, string> pair in phrasesToUrls)
            {
                // Replace phrases with placeholders.
                string placeholder = Guid.NewGuid().ToString();
                text = text.Replace(pair.Key, placeholder);
                // Create dictionary of links by placeholder
                string link = string.Format(
                    "<a href=\"{0}\">{1}</a>",
                    pair.Value,
                    pair.Key);
                placeholdersToLinks.Add(placeholder, link);
            }
            // Phase 2: replace unique placeholders with links.
            foreach (KeyValuePair<string, string> pair in placeholdersToLinks)
            {
                text = text.Replace(pair.Key, pair.Value);
            }
            return text;
        }
    
        public int Compare(string x, string y)
        {
            if (x.Length > y.Length) return -1;
            if (x.Length < y.Length) return +1;
            // Equal length strings still need to be differentiated, otherwise
            // they will be treated as the same key by the  dictionary.
            return x.CompareTo(y);
        }
    }
