    using System;
    
    class Person
    {
        public string Name { get; set; }
        public string Mail { get; set; }
    }
    
    class Program
    {
        private void ObjectInitializer()
        {
            Person person = new Person()
            {
                Name = "Philippe",
                Mail = "phil@phil.com",
            };
            person.ToString();
        }
    
        private void SetProperties()
        {
            Person person = new Person();
            person.Name = "Philippe";
            person.Mail = "phil@phil.com";
            person.ToString();
        }
    
        private const int repetitions = 100000000;
    
        private void Time(Action action)
        {
            DateTime start = DateTime.UtcNow;
            for (int i = 0; i < repetitions; ++i)
            {
                action();
            }
            DateTime end = DateTime.UtcNow;
            Console.WriteLine(repetitions / (end - start).TotalSeconds);
        }
    
        private void Run()
        {
            Time(ObjectInitializer);
            Time(SetProperties);
            Console.WriteLine("Finished");
            Console.ReadLine();
        }
    
        private static void Main()
        {
            new Program().Run();
        }
    }
