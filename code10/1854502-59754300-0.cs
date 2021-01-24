        public class SubScriber
        {
            public SubScriber()
            {
                int i = 5;
                Action action1 = () =>
                {
                    Console.WriteLine("Event Fired action1");//not getting called
                    i = 11; //commenting this line will execute the subscription code
                };
                Action action2 = () =>
                {
                    Console.WriteLine("Event Fired action2");//will be called
                };
                Console.WriteLine("Target 1 = "+ action1.Target);
                Console.WriteLine("Target 2 = " + action2.Target);
                PrismEvents.EventTest.Subscribe(action1);
                PrismEvents.EventTest.Subscribe(action2);
            }
            ~SubScriber()
            {
                Console.WriteLine("SubScriber destructed");
            }
        }
        static void Main(string[] args)
        {
            new SubScriber();
            GC.Collect(); //commenting this line will execute the subscription code
            GC.WaitForPendingFinalizers(); // or Thread.Sleep(2000);
            Console.WriteLine("Publish");
            PrismEvents.EventTest.Publish();
            Console.WriteLine("Press a key to finish");
            Console.ReadKey();
        }
