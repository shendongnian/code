    public class Class1
    {
        public static void MyMethod(Action<object> obj)
        {
             obj("Hey!");
        }
    }
    
    public class Class2
    {
        public Action<object> CallBack = obj => Console.WriteLine(obj.ToString());
    }
