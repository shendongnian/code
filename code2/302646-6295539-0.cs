    IEnumerable<string> butcherTheList(IEnumerable<string> input)
    {
        foreach (string current in input)
        {
            if(case1(current))  
            {
                yield return current;
            }
            else if(case2(current))
            {
                yield return current;
                yield return someFunc(current);
            }
            // default behavior is to yield nothing, effectively removing the item
        }
    }
    
    List<string> newList = butcherTheList(input).ToList();
            
         
