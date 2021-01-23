    private static object doSomethingLock = new object();
    public static void DoSomething (string param1, string param2, SomeObject o) 
    {
       //.....
    
       lock(doSomethingLock) 
       {
           o.Things.Add(param1);
           o.Update();
           // etc....
       }
    }
