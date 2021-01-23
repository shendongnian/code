    private static List<string> _censoredWords = new List<string>()
                                                      {
                                                          "badwordone1",
                                                          "badwordone2",
                                                          "badwordone3",
                                                          "badwordone4",
                                                      };
            
    
            static void Main(string[] args)
            {
                string badword1 = "BadWordOne2";
                bool censored = ShouldCensorWord(badword1);
            }
    
            private static bool ShouldCensorWord(string word)
            {
                return _censoredWords.Contains(word.ToLower());
            }
