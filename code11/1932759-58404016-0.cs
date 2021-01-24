    abstract class Animal
    {
        public abstract Lion KingOfTheJungle { get; }
    
    }
    
    class Lion : Animal
    {
        public override Lion KingOfTheJungle
        {
            get
            {
                return this;
            }
        }
    }
