    using System;
    using System.Threading;
 
    class Program
    {
        static MyComObject m_Object;
        static AutoResetEvent m_Event;
        [MTAThread]
        static void Main(string[] args)
        {
            m_Event = new AutoResetEvent(false);
            m_Object = new MyComObject();
            m_Object.OnEvent += ObjectEvt;
            Console.WriteLine("Main thread waiting...");
            m_Event.WaitOne();
            Console.WriteLine("Main thread got event, exiting.");
            // This exits after just one event; add loop or other logic to exit properly when appropriate.
        }
        void ObjectEvt(/*...*/)
        {
            Console.WriteLine("Received event, doing work...");
            // ... note that this could be on any random COM thread.
            Console.WriteLine("Done work, signalling event to notify main thread...");
            m_Event.Set();
        }
    }
