        private string fullSentence;
        private string[] words;
        private Dictionary<char, string> acronymDictionary = new Dictionary<char, string>();
        public Acronym(string sentence)
        {
            fullSentence = sentence;
            words = sentence.Split(' ');
    
        }
    
        public void BuildAcronym()
        {
            if(words != null)
            { 
            char[] key = new char[words.Length];
            //key = null;
            //foreach (string info in words)
            //{
                for (int i = 0; i < words.Length; i++)
                {
                    key[i] = Convert.ToChar(words[i].Substring(0,1)); //this is where the problem is
                }
             }
         }
