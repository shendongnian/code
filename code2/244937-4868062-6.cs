    List<MyType> removeItems = new List<MyType>();
    foreach(MyType item in results)
    {
       if(someCondition)
       {
            removeItems.Add(item);
       }
    }
    foreach (MyType item in removeItems)
        results.Remove(item);
