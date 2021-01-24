    static void Main(string[] args)
            {
                var wordFreq = new Dictionary<string, int>();
                using (var fileStream = File.Open("text.in", FileMode.Open, FileAccess.Read))
                using (var streamReader = new StreamReader(fileStream))
                {
                    string line;
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        var words = Regex.Split(line, @"[^A-Za-z]+");
                        foreach (var word in words)
                        {
                         if (word.Equals("")) { continue; }   
                                if (wordFreq.ContainsKey(word))
                                {
                                    wordFreq[word]++;
                                }
                                else
                                {
                                    wordFreq.Add(word, 1);
                                }               
                        }
                    }
                }    
