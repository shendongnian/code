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
