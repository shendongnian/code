    public class Animal
    {
        public bool isAlive = true;
        public List<Animal> friends;
        public virtual bool HatesMe
        {
            get
            {
                return false;
            }
        }
    }
    public class Dog : Animal
    {
        public string Bark()
        {
            return "Woof!";
        }
    }
    public class Cat : Animal
    {
        public override bool HatesMe
        {
            get
            {
                return true;
            }
        }
    }
    public class GoldenRetriever : Dog
    {
        public bool greatForFamilies = true;
    }
