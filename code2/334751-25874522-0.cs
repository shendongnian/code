    public class Tester
    {
        public static void Test()
        {
            Animal a = new Animal();
    
            //nothing is printed
            foreach (Dog d in a.Each<Dog>())
            {
                Console.WriteLine(d.Name);
            }
    
            Dog dd = new Dog();
    
            //dog ID is printed
            foreach (Dog dog in dd.Each<Dog>())
            {
                Console.WriteLine(dog.ID);
            }
        }
    }
    
    public class Animal
    {
        public Animal()
        {
            Console.WriteLine("Animal constructued:" + this.ID);
        }
    
        private string _id { get; set; }
    
        public string ID { get { return _id ?? (_id = Guid.NewGuid().ToString());} }
    
        public bool IsAlive { get; set; }
    }
    
    public class Dog : Animal 
    {
        public Dog() : base() { }
    
        public string Name { get; set; }
    }
    
    public static class ObjectExtensions
    {
        public static IEnumerable<T> Each<T>(this object Source)
            where T : class
        {
            T t = Source as T;
    
            if (t == null)
                yield break;
    
            yield return t;
        }
    }
