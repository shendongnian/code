    public class Dog : Animal
    {
        public static readonly AnimalType Type = new AnimalType(sound: "Woof!");
        override public AnimalType AnimalType
        {
            get { return Type; }
        }
    }
    public class Cat : Animal
    {
        public static readonly AnimalType Type = new AnimalType(sound: "Mee-oww.");
        override public AnimalType AnimalType
        {
            get { return Type; }
        }
    }
