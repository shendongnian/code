    static void Main ()
    {
        List<string> words = new List<string>();
        words.AddRange(new[] { "banana", "plum", "peach" });
        words.RemoveAll(s=>s.Any());//This code returns empty list
     }
