    public static IEnumerable<Tag> CreateTags(IEnumerable<string> words)
        {
            if(words==null)
            {
               //either throw a new ArgumentException or
               return null; //or return new Dictionary<string,int>();
            }
            Dictionary<string, int> tags = new Dictionary<string, int>();
    
            foreach (string word in words)
            {
                int count = 1;
                if (tags.ContainsKey(word))
                {
                    count = tags[word] + 1;
                }
    
                tags[word] = count;
            }
    
            return tags.Select(kvp => new Tag(kvp.Key, kvp.Value));
        }
