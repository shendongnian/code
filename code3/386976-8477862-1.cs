    List<Item> myItem = new List<Item>();
    List<Type> myOrder = new List<Item>();
    Dictionary<Type, int> myCount = new Dictionary<Type, int>();
    foreach (var item in myItem)
    {
     if (myCount.ContainsKey(item.GetType()))
     {
      myCount[item.GetType()]++;
     }
     else
     {
      myOrder.Add(item.GetType());
      myCount.Add(item.GetType(), 1);
     }
    }
    
    List<Item> testingItems = new List<Item>();
    int[] testingCounts = new int[myCount.Count];
    while(IncrementCounts(testingCounts, myOrder, myCount)) {
     for(int x=0; x<testingCounts.length; x++) {
      AddInstances( testingItems, myOrder[x], testingCounts[x] );
     }
     // doTest()
     testingItems.Clear();
    }
    // count permutations using the maxima
    // EXAMPLE: maxima [2, 2, 2]
    //  1,0,0; 2,0,0; 0,1,0; 1,1,0; 2,1,0; 0,2,0; 1,2,0; 2,2,0; 0,0,1; 1,0,1; 2,0,1 etc..
    public static bool IncrementCounts(int[] counts, List<Type> order, Dictionary<Type, int> maxima) {
     for(int x=0; x<counts.length; x++) {
      if(counts[x] + 1 <= maxima[order[x]]) {
       counts[x]++;
       return true;
      } else {
       counts[x] = 0;
      }
     }
     return false; // overflow, so we're finished
    }     
    
    public static void AddIstances(List<Item> list, Type type, int count) {
     for(int x=0; x<count; x++) {
      list.Add( Convert.ChangeType( Activator.CreateInstance(type), type ) );
     }
    }
