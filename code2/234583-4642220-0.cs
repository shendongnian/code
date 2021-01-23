    private static void DoSomethingOnItem(string wanted)
    {
       foreach (var item in items)
       {
          if (item.name == wanted)
          {
             lock (item)
                item.DoSomething();
          }
       }
    }
