    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace Generic_Delegates_and_Events
    {
        public delegate void GenericEventHandler<S,A>(S sender,A args); //generic delegate
    
        public class MyPublisher
        {
            public event GenericEventHandler<MyPublisher,EventArgs> MyEvent;
            public void FireEvent()
            {
                MyEvent(this,EventArgs.Empty);
            }
        }
        
        public class MySubscriber<A> //Optional: can be a specific type
        {
            public void SomeMethod(MyPublisher sender,A args)
            {
                Console.WriteLine("MySubscriber::SomeMethod()");
            }
        }
        public class MySubscriber2<A> //Optional: can be a specific type
        {
            public void SomeMethod2(MyPublisher sender, A args)
            {
                Console.WriteLine("MySubscriber2::SomeMethod2()");
            }
        }
        class Program
        {
            static void Main(string[] args)
            {
                MyPublisher publisher = new MyPublisher();
                MySubscriber<EventArgs> subscriber = new MySubscriber<EventArgs>();
                publisher.MyEvent += subscriber.SomeMethod;
                MySubscriber2<EventArgs> subscriber2 = new MySubscriber2<EventArgs>();
                publisher.MyEvent += subscriber2.SomeMethod2;
                publisher.FireEvent();
            }
        }
    }
