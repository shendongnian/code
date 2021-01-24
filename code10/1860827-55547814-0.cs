    using System;
    using System.Threading;
    
    namespace EventHandling
    {
        class Program
        {
            static void Main(string[] args)
            {
                var eventProvider = new EventProvider();
                eventProvider.Event += (sender, e) => Console.WriteLine("Event fired");
                eventProvider.FireEvent();
            }
        }
    
        class EventProvider
        {
            public event EventHandler Event;
    
            protected void OnEvent(EventArgs e) => Volatile.Read(ref Event)?.Invoke(this, e);
    
            public void FireEvent() => OnEvent(EventArgs.Empty);
        }
    }
