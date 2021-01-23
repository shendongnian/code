    public class AnimalType
    {
        public AnimalType(string sound)
        {
            Sound = sound;
        }
        public string Sound { get; private set; }
        private static IDictionary<Type, AnimalType> _types = new Dictionary<Type, AnimalType>();
        public static void Register(Type type, AnimalType animalType)
        {
            _types.Add(type, animalType);
        }
        public static AnimalType Get(Type type)
        {
            return _types[type];
        }
    }
    public abstract class Animal
    {
        public abstract AnimalType AnimalType { get; }
    }
    public class Dog : Animal
    {
        public static readonly AnimalType Type = new AnimalType(sound: "Woof!");
        static Dog()
        {
            AnimalType.Register(typeof(Dog), Type);
        }
        override public AnimalType AnimalType
        {
            get { return Type; }
        }
    }
    public class Cat : Animal
    {
        public static readonly AnimalType Type = new AnimalType(sound: "Mee-oww.");
        static Cat()
        {
            AnimalType.Register(typeof(Cat), Type);
        }
        override public AnimalType AnimalType
        {
            get { return Type; }
        }
    }
    public void Test()
    {
        Animal dog = new Dog();
        Animal cat = new Cat();
        Assert.AreEqual(dog.AnimalType.Sound, Dog.Type.Sound);
        Assert.AreEqual(cat.AnimalType.Sound, Cat.Type.Sound);
        var dogType = typeof (Dog);
        var catType = typeof (Cat);
        Assert.AreEqual(Dog.Type.Sound, AnimalType.Get(dogType).Sound);
        Assert.AreEqual(Cat.Type.Sound, AnimalType.Get(catType).Sound);
    }
