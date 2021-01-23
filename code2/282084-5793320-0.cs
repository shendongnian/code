    using System;
    using System.Collections.ObjectModel;
    class Test
    {
        public Test()
        {
            this.Collection = new Collection<int>();
        }
        public Collection<int> Collection { get; private set; }
        public static void Main()
        {
            // Note the use of collection intializers here...
            Test test = new Test
                {
                    Collection = { 3, 4, 5 }
                };
            foreach (var i in test.Collection)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }  
    }
