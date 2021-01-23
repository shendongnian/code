    public class Animal
    {
        public virtual string GetFood()
        {
            return "Food";         
        }
    }
    public class Monkey : Animal
    {
        public override string GetFood()
        {
            return "Bananas";
        }
    }
    public class Cow : Animal
    {
        public override string GetFood()
        {
            return "Grass";
        }
    }
