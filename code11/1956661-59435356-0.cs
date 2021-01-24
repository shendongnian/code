    class Person : ICloneable
    {
        public string name;
        public City city;
        
        public object Clone()
        {
            return this.MemberwiseClone();
        }
        public Person DeepCopyAndDisposeCity()
        {
            return new Person()
            {
                name = this.name,
                city = null
            };
        }
    }
**Program**:
            Person person = new Person()
            {
                name = "John",
                city = new City("London")
            };
            Person personNew = person.DeepCopyAndDisposeCity(); //(Person)person.Clone();
            //personNew.city = new City( "Hanoi");
            string cityOfNewPersion= personNew.city == null ? "null" : personNew.city.name;
            Console.WriteLine("Person:");
            Console.WriteLine($"{person.name}\t\n{person.city.name}");
            Console.WriteLine("New Person:");
            Console.WriteLine($"{personNew.name}\t\n{cityOfNewPersion}");
            Console.ReadKey();
