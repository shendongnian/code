        private void CountWords()
        {
            string text = "The Keldholme Priory election dispute occurred in Yorkshire, England, in 1308. The Archbishop of York, William Greenfield, appointed one of the nuns to lead the house after a series of resignations by its prioresses. His candidate, Emma de Ebor', was deemed unacceptable by many nuns, and she resigned three months later. The Archbishop next appointed Joan de Pykering from nearby Rosedale Priory, but the nuns resisted her as well. The Archbishop attempted to quash the nuns' rebelliousness, exiling some to surrounding priories and threatening others with excommunication. The convent was not deterred, and eventually Greenfield allowed the nuns to elect one of their number again. They first re-elected Emma de Stapleton, who had been prioress in 1301, but she also became unpopular, and resigned. They eventually re-elected Emma de Ebor'. The election dispute evaporated, and little more was heard of the priory until its dissolution in 1536";
            char[] sp = new[] { ' ' };
            string[] words = text.Split(sp);
            Dictionary<string, int> WordCount = new Dictionary<string, int>();
            char[] punctuation = new[] { ',', '.' }; //probably need to more punctuation characters
            foreach (string word in words)
            {
                string CleanWord =word.Trim(punctuation);
                CleanWord = CleanWord.ToLower();
                if (WordCount.ContainsKey(CleanWord))
                {
                    WordCount[CleanWord]++;
                }
                else
                {
                    WordCount.Add(CleanWord, 1);
                }
            }
            foreach (KeyValuePair<string, int> kv in WordCount)
            {
                Debug.Print($"{kv.Key} {kv.Value}");
            }
        }
