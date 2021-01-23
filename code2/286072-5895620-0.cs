        int topN = 3;
        List<string> topNWords = new List<string>();
        string[] words = new string[] {
            "word5",
            "word1",
            "word1",
            "word1",
            "word2",
            "word2",
            "word2",
            "word3",
            "word3",
            "word4",
            "word5",
            "word6",
        };
        var wordGroups = from s in words
                           group s by s into g
                           select new { Count = g.Count(), Word = g.Key };
        for (int i = 0; i < Math.Min(topN, wordGroups.Count()); i++)
        {
            var element = wordGroups.OrderBy((g) => g.Count).Reverse().ElementAt(i);
            topNWords.Add(element.Count + " - " + element.Word);
        }
