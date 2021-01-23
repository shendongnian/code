    public static string ClosestWord(string word, string[] terms)
    {
        string term = word.ToLower();
        List<string> list = terms.ToList();
        if (list.Contains(term))
            return list.Find(t => t.ToLower() == term);
        else
        {
            int[] counter = new int[terms.Length];
            for (int i = 0; i < terms.Length; i++)
            {
                for (int x = 0; x < Math.Min(term.Length, terms[i].Length); x++)
                {
                    int difference = Math.Abs(term[x] - terms[i][x]);
                    counter[i] += difference;
                }
            }
            
            int min = counter.Min();
            int index = counter.ToList().FindIndex(t => t == min);
            return terms[index];
        }
    }
