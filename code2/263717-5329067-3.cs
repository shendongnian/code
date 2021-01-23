        List<string> strings = new List<string>{ "johnny", "happy", "people" };
        Dictionary< string, letters> processedWordList;
        void processList()
        {
            foreach (string s in strings)
            {
                //there should probably be a constructor in letters which does some of this 
                string lowered = s.ToLower();
                Letters letters;
                foreach (char c in lowered)
                {
                    ++letters.count[c];
                }
                processedWordList.Add(s, letters);
            }
        }
