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
    int numOfTests = 1;
    for(int x=0; x<myOrder.Count; x++) { // num of tests loop
     numOfTests *= myCount[myOrder[x]]
     for(int y=0; y<numOfTests; y++) { // testing loop
      for(int z=0; z<=x; z++) { // item instancing loop
       AddInstances( testingItems, myOrder[z], myCount[myOrder[z]] );
      }
      // doTest()
      testingItems.Clear();
     }
    }
    
    public static void AddIstances(List<Item> list, Type type, int count) {
     for(int x=0; x<count; x++) {
      list.Add( Convert.ChangeType( Activator.CreateInstance(type), type ) );
     }
    }
