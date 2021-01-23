    public static void Main()
    {
       while (true) {
         var t = myobj.DoSomething(null);
         t.Wait();
         if(t.HasException) {
           break;
         }
       }
       Console.Write("done");
       //...
      }
    }
    //...
    public async Task DoSomething(string p)
    {
      if (p==null) throw new InvalidOperationException();
      else await SomeAsyncMethod();
    }
