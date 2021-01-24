    class IntgerValueChangedPublisher
    {
        public int MyVar { 
            get => _myVar; 
            set { 
                _myVar = value; 
                Publish(); 
            } 
        }
        private int _myVar = 0;
        private ICollection<IntegerValueChangedSubscriber> _subscribers = new LinkedList<IntegerValueChangedSubscriber>();
        public void Publish()
        {
            foreach(var subscriber in _subscribers)
            {
                subscriber.Receive(_myVar);
            }
        }
        public void Subscribe(IntegerValueChangedSubscriber subscriber)
        {
            _subscribers.Add(subscriber);
        }
    }
    class IntegerValueChangedSubscriber
    {
        public void Receive(int value)
        {
            if (value.Equals(0))
            {
                Console.WriteLine("Dead");
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            IntgerValueChangedPublisher valueChangedPublisher = new IntgerValueChangedPublisher();
            IntegerValueChangedSubscriber integerValueSubscriber = new IntegerValueChangedSubscriber();
            valueChangedPublisher.Subscribe(integerValueSubscriber);
            while (!Console.ReadLine().Equals("kill"))
            {
                // keep looping until "kill" is entered
            }
            valueChangedPublisher.MyVar = 0;
        }
    }
