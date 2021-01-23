    public abstract class Animal
    {
        public static abstract string Sound { get; }
    }
    
    public class Cat : Animal
    {
        public static string Sound
        {
            get { return "Mee-oww."; }
        }
    }
    public class Dog : Animal
    {
        public static string Sound
        {
            get { return "Woof!"; }
        }
    }
    public void Test()
    {
        Animal cat = new Cat();
        Animal dog = new Dog();
        
        Assert.AreEqual(cat.GetType().Sound, Cat.Sound);
        Assert.AreEqual(dog.GetType().Sound, Dog.Sound);
    }
