    public abstract class Task
    {
        private readonly string description;
        protected Task(string description)
        {
            this.description = description;
        }
    }
    public class Walk : Task
    {
        public Walk() : base("Do walk")
        {
        }
    }
