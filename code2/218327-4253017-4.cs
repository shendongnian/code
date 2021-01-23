     public class b:A
    {
        
        public b()
        {
            
            MyEventNotifier.OnChange += new EventHandler(delegate { Console.WriteLine("Hi"); });
           MyEventNotifier.HasChanged = true;
        }
    }
    
