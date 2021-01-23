    List<object> list2 = new List<object>();
    for(int i = 0; i < 1000; i++)
    {
       List<object>list1 = new List<object>();
       for(int j = 0; j< 1000; j++)
       {
          list1.Add( "something" + j);
       }
       list2.Add(list1);
    }
