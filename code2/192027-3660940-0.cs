    abstract class Animal
    {
        public virtual void DoSomething() { }
    }
    interface ICanEat
    {
        void Eat();
    }
    class Dog : Animal, ICanEat
    {
        public void Eat()
        {
            Console.Out.WriteLine("Dog eat");
        }
    }
    class Cat : Animal, ICanEat
    {
        public void Eat()
        {
            Console.Out.WriteLine("Cat eat");
        }
    }
    class Person
    {
        public Animal MyAnimal { get; set; }
    }
