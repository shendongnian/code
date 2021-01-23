    using System;
    using System.Reflection;
    
    class CustomEventArgs : EventArgs {}
    
    delegate void CustomEventHandler(object sender, CustomEventArgs e);
    
    class Publisher
    {
        public event EventHandler PlainEvent;
        public event EventHandler<CustomEventArgs> GenericEvent;
        public event CustomEventHandler CustomEvent;
        
        public void RaiseEvents()
        {
            PlainEvent(this, new EventArgs());
            GenericEvent(this, new CustomEventArgs());
            CustomEvent(this, new CustomEventArgs());
        }
    }
    
    class Test
    {
        static void Main()
        {
            Publisher p = new Publisher();
            
            Type type = typeof(Publisher);
            
            foreach (EventInfo eventInfo in type.GetEvents())
            {
                string name = eventInfo.Name;
                EventHandler handler = (s, args) => ReportEvent(name, s, args);
                // Make a delegate of exactly the right type
                Delegate realHandler = Delegate.CreateDelegate(
                     eventInfo.EventHandlerType, handler.Target, handler.Method);
                eventInfo.AddEventHandler(p, realHandler);
            }
            
            p.RaiseEvents();
        }
        
        static void ReportEvent(string name, object sender, EventArgs args)
        {
            Console.WriteLine("Event {0} name raised with args type {1}",
                              name, args.GetType());
        }
    }
