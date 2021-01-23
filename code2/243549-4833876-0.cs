    using System;
    namespace Events
    {
       class Program
        {
            static void Main(string[] args)
            {
                Events e = new Events();
                e.FireEvents();
                Console.ReadLine();
            }
        }
        public class Events
        {
            private event EventHandler<EventArgs> EventTest;
            public Events()
            {
                EventTest += new EventHandler<EventArgs>(function);
                EventTest += delegate
                {
                    Console.WriteLine("written by an anonymous method.");
                };
                EventTest += (o, e) =>
                {
                    Console.WriteLine("written by a lambda expression");
                };
            }
            private void function(object sender, EventArgs e)
            {
                Console.WriteLine("written by a function.");
            }
            public void FireEvents()
            {
                if (EventTest != null)
                    EventTest(this, new EventArgs()); 
            }
        }
    }
