    namespace EventTest
    {
        public class Publisher
        {
            public delegate void SomeEvent(object sender);
            public event SomeEvent OnSomeEvent;
            public event SomeEvent OnOtherEvent;
        }
    
        public class Subscriber
        {
            public Subscriber(Publisher p)
            {
                p.OnSomeEvent += new Publisher.SomeEvent(Respond);
                p.OnOtherEvent += Respond;
            }
    
            public void Respond(object sender)
            {
    
            }
        }
    }
