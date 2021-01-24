    var count = 2;
    var temp = new List<object>();
    // Will generate random numbers.
    var random = new Random();
    
    foreach (var m in Enumerable.Range(0, count).Select(i => arr[random.Next(arr.Count())]))
    {
        // Ensures that duplicates will not be added.
        if (!temp.Contains(m))
        {
            temp.Add(m);
        }
    }
    
    // Add generated items into the JArray and then use it.
    var item = new JArray(temp);
