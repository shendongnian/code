    public class Test
    {
       public static void ExecuteLambdaInScope()
       {
          // here, the lambda executes only within the scope
          // of the referenced variable 'add'
          var items = Enumerable.Range(0, 100000).ToArray();
          int add = 10;  // free variable referenced from lambda
          Func<int,int> f = x => x + add;
          // measure how long this takes:
          var array = items.Select( f ).ToArray();  
       }
       static Func<int,int> GetExpression()
       {
          int add = 10;
          return x => x + add;  // this needs a closure
       }
       static void ExecuteLambdaOutOfScope()
       {
          // here, the lambda executes outside the scope
          // of the referenced variable 'add'
          Func<int,int> f = GetExpression();
          var items = Enumerable.Range(0, 100000).ToArray();
          // measure how long this takes:
          var array = items.Select( f ).ToArray();  
       }
    }
