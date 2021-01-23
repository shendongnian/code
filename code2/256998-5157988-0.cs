    public abstract class Task
    {
        private const string description = "default description";
        public virtual string Description { get { return description; } }
    }
    
    public class Walk : Task
    {
        private const string description = "Do walk";
        public override string Description { get { return description; } }
    }
