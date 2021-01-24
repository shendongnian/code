    using System;
    using System.Threading;
    using System.Threading.Tasks;
    
    namespace EventHandling
    {
        class Program
        {
            static void Main(string[] args)
            {
                while(true)
                    new Program().Run();
            }
    
            private void Run()
            {
                var eventProvider = new EventProvider();
                eventProvider.Event += HandleEvent;
                Console.WriteLine("subscribed");
    
                var unsubscribe = new Task(() =>
                {
                    eventProvider.Event -= HandleEvent;
                    Console.WriteLine("unsubscribed");
                });
    
                var fireEvent = new Task(() => eventProvider.FireEvent());
    
                fireEvent.Start();
                unsubscribe.Start();
    
                Task.WaitAll(fireEvent, unsubscribe);
    
                Console.ReadLine();
            }
    
            private void HandleEvent(object sender, EventArgs e) => Console.WriteLine("Event fired");
    
            
        }
    
        class EventProvider
        {
            public event EventHandler Event;
    
            protected void OnEvent(EventArgs e)
            {
                var temp = Volatile.Read(ref Event);
                Console.WriteLine("temp delegate created");
                Thread.Sleep(25); // time to unsubscribe concurrently
    
                if (temp != null)
                {
                    Console.WriteLine("temp delegate invoking");
                    temp.Invoke(this, e);
                    Console.WriteLine("temp delegate invoked");
                }
                else
                    Console.WriteLine("temp delegate is empty");
            }
    
            public void FireEvent() => OnEvent(EventArgs.Empty);
        }
    }
