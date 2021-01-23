    public void DisplayAllIndexes(string text, string search)
    {
        //Argument Validation
        if (text == null) throw new ArgumentNullException("text");
        if (search == null) throw new ArgumentNullException("search");
        
        int index = 0;
    
        while ((index = text.IndexOf(search, index)) != -1)
        {
            Console.WriteLine("Found at position {0}", index);
    
            index += search.Length;
        }
    }
