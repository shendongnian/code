    public interface IBusiness
    {
        string Name { get; }
    }
    public abstract class Business : IBusiness
    {
        public abstract string Name { get; }
    }
    public class Casino : Business  
    {
        public override string Name
        {
            get { return "Casino Corp"; }
        }
    }
    public class DrugStore : Business 
    {
        public override string Name
        {
            get { return "DrugStore business"; }
        }
    }
