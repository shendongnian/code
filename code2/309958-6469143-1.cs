    public class Test
    {
        public void Hello(string s) { Console.WriteLine("hello " + s); }
    }
    
    ...
    
    {
         Test t = new Test();
         typeof(Test).GetMethod("Hello").Invoke(t, new[] { "world" }); 
         // alternative if you don't know the type of the object:
         t.GetType().GetMethod("Hello").Invoke(t, new[] { "world" }); 
    }
