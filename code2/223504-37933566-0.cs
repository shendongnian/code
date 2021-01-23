    using System;
    namespace ConsoleApplication1
    {
        class Program
        {
            class HasEvent
            {
                public event EventHandler OnEnvent;
                EventInvoker myInvoker;
                public HasEvent()
                {
                    myInvoker = new EventInvoker(this, () => OnEnvent);
                }
                public void MyInvokerRaising() {
                    myInvoker.Raise();
                }
            }
            class EventInvoker
            {
                private Func<EventHandler> GetEventHandler;
                private object sender;
                public EventInvoker(object sender, Func<EventHandler> GetEventHandler)
                {
                    this.sender = sender;
                    this.GetEventHandler = GetEventHandler;
                }
                public void Raise()
                {
                    if(null != GetEventHandler())
                    {
                        GetEventHandler()(sender, new EventArgs());
                    }
                }
            }
            static void Main(string[] args)
            {
                HasEvent h = new HasEvent();
                h.OnEnvent += H_OnEnvent;
                h.MyInvokerRaising();
            }
            private static void H_OnEnvent(object sender, EventArgs e)
            {
                Console.WriteLine("FIRED");
            }
        }
    }
