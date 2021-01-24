    class Program
    {
        static void Main(string[] args)
        {
            Object person = new Person();
            Animal animal = person as Animal;
        }
    }
    class Person
    { }
    class Animal
    { }
