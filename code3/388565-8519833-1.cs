    private static IOrderedEnumerable<int> ReturnOrdered(){return new int[]{1,2,3}.OrderBy(x => x);}
    private static IEnumerable<int> ReturnOrderUnknown(){return ReturnOrdered();}//same object, diff return type.
    private static void UseEnumerable(IEnumerable<int> col){Console.WriteLine("Unordered");}
    private static void UseEnumerable(IOrderedEnumerable<int> col){Console.WriteLine("Ordered");}
    private static void ExamineEnumerable(IEnumerable<int> col)
    {
      if(col is IOrderedEnumerable<int>)
        Console.WriteLine("Enumerable is ordered");
      else
        Console.WriteLine("Enumerable is unordered");
    }
    public static void Main(string[] args)
    {
      //Demonstrate compile-time loses info from return types
      //if variable can take either:
      var orderUnknown = ReturnOrderUnknown();
      UseEnumerable(orderUnknown);//"Unordered";
      orderUnknown = ReturnOrdered();
      UseEnumerable(orderUnknown);//"Unordered"
      //Demonstate this wasn't a bug in the overload selection:
      UseEnumerable(ReturnOrdered());//"Ordered"'
      //Demonstrate run-time will see "deeper" than the return type anyway:
      ExamineEnumerable(ReturnOrderUnknown());//Enumerable is ordered.
    }
