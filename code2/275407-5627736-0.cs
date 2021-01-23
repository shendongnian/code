    using System;
    using System.Reflection;
     
    namespace TestProject
    {
        public delegate void MyEventHandler(object sender, EventArgs e);
     
        public class MyClass
        {
            public event MyEventHandler MyEvent;
     
            public void TriggerMyEvent()
            {
                if (MyEvent != null)
                {
                    MyEvent(null, null);
                }
                else
                {
                    Console.WriteLine("No event handler registered.");
                }
            }
        }
     
        public static class MyExt
        {
            public static void OneShot<TA>(this TA instance, string eventName, MyEventHandler handler)
            {
                EventInfo i = typeof (TA).GetEvent(eventName);
                MyEventHandler newHandler = null;
                newHandler = (sender, e) =>
                                 {
                                     handler(sender, e);
                                     i.RemoveEventHandler(instance, newHandler);
                                 };
                i.AddEventHandler(instance, newHandler);
            }
        }
     
        public class Program
        {
            static void Main(string[] args)
            {
                MyClass c = new MyClass();
                c.OneShot("MyEvent",(sender,e) => Console.WriteLine("Handler executed."));
                c.TriggerMyEvent();
                c.TriggerMyEvent();
            }
        }
    }
