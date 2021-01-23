    public static void DoSomething (string param1, string param2, SomeObject o, object someObjectLock) 
    {
       //.....
    
       lock(someObjectLock) 
       {
           o.Things.Add(param1);
           o.Update();
           // etc....
       }
    }
