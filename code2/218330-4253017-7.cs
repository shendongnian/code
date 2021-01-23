     public class b
    {
        A obj ;
        public b()
        {
            obj = new A();
            obj.MyEventNotifier.OnChange += new EventHandler(delegate { Console.WriteLine("Hi"); });
            obj. MyEventNotifier.HasChanged = true;
        }
    }
    
