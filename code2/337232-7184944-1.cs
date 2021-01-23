    public static IEnumerable<T> PickRandom(int requested, IEnumerable<Stock<T>> list)
    {
        var allStock = list.SelectMany(item => 
            Enumerable.Range(0, item.Available).Select(r => item.Item)).ToList();
                
        Random rng = new Random(); 
                
        for (int n = 0; n < requested; n++) 
        { 
            int choice = rng.Next(0, allStock.Count - 1);
            var result = allStock[choice];
            allStock.RemoveAt(choice);
                    
            yield return result;
        }  
    }
