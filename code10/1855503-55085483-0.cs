    class Program
    {
        
        public abstract class Animal<T> where T : Animal<T>
        {
            public static List<Action<T>> Augmenters = new List<Action<T>>();
        }
        public class Dog : Animal<Dog>
        {
            
        }
        public class Cat : Animal<Cat>
        {
            
        }
        // in another place of the code, augmenters are added and configured
        public static void Main(string[] args)
        {
            Dog.Augmenters.Add(dog =>
            {
                Console.WriteLine("bark");
            });
            Cat.Augmenters.Add(cat =>
            {
                Console.WriteLine("meow");
            });
            Dog.Augmenters[0].Invoke(new Dog());
            Cat.Augmenters[0].Invoke(new Cat());
            Console.ReadLine();
        }
    }
