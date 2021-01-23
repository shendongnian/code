    public class Person
    {
        public int Age { get; private set; }
        public string Name { get; private set; }
        public Person(int age, string name)
        {
            Age = age;
            Name = name;
        }
    }
