    [Test]
    public void TestEventIsRaised()
    {
        TestEventSubscriber subscriber = new TestEventSubscriber();
        subscriber.SetFirstName("joe");
        Assert.IsTrue(subscriber.EventWasHandledInTestDouble);
    }
    public class TestEventSubscriber : EventSubscriber
    {
        public bool EventWasHandledInTestDouble;
        public TestEventSubscriber()
        {
            
        }
        protected override void OnMyEvent(object sender, EventArgs args)
        {
            EventWasHandledInTestDouble = true;
        }
    }
    public class EventSubscriber
    {
        private EventRaiser eventRaiser = new EventRaiser();
        
        public EventSubscriber()
        {
            eventRaiser.MyEvent += (sender, args) => {
                Console.Write("Event was handled via anonymous delegate");
            };
            eventRaiser.MyEvent = OnMyEvent;
        }
        public void SetFirstName(string firstName)
        {
            eventRaiser.FirstName = "bob";
        }
        protected virtual void OnMyEvent(object sender, EventArgs args)
        {
            Console.WriteLine("Event was handled via virtual method...");
        }
    }
    public class EventRaiser
    {
        public EventHandler MyEvent;
        public EventRaiser()
        {
            
        }
        private string firstName;
        public string FirstName
        {
            get
            {
                return firstName;
            }
            set
            {
                firstName = value;
                EventHandler handler = this.MyEvent;
                if (handler != null)
                    MyEvent(this, EventArgs.Empty);
            }
        }
    }
