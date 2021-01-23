    void Main()
    {
        var listOne = new string[] { "dog", "cat", "car", "apple"};
        var listTwo = new string[] { "car", "apple"};
     
        var elements = listTwo.Where(e => listOne.Contains(e))
            .Concat(listOne.Where(e => !listTwo.Contains(e)));
        
        elements.Dump();
    }
