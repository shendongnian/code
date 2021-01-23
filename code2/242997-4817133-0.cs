    int CountItemsLargerThanFive(IEnumerable<int> collection)
    {
       int count = 0;
       foreach (var item in collection)
       {
          if (item > 5)
          {
             count++;
          }
       }
       return count;
    }
