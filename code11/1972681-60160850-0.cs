    class Program
    {
        static void Main(string[] args)
        {
            EventTest e = new EventTest(); /* Instantiate the object, without triggering event */
            subscribEvent v = new subscribEvent(); /* Instantiate object */
            e.ChangeNum += new EventTest.NumManipulationHandler(v.printf); /* subscribe the event */
            e.SetValue(7);
            e.SetValue(11);
        }
    }
    public class EventTest
    {
        private int value;
        public delegate void NumManipulationHandler();
        public event NumManipulationHandler ChangeNum;
        protected virtual void OnNumChanged()
        {
            if (ChangeNum != null)
            {
                ChangeNum(); /* Trigger the event */
            }
            else
            {
                Console.WriteLine("event not fire");
                Console.ReadKey(); /* Press enter to continue */
            }
        }
        public EventTest()
        {
            int n = 5;
            SetValue(n);
        }
        public void SetValue(int n)
        {
            if (value != n)
            {
                value = n;
                OnNumChanged();
            }
        }
    }
    // Subscriber class
    public class subscribEvent
    {
        public void printf()
        {
            Console.WriteLine("event fire");
            Console.ReadKey(); /* Press enter to continue */
        }
    }
