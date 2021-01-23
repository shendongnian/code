    public abstract class Task
    {
        public string Description { get; private set; }
    
        protected Task(string description)
        {
            this.Description = description;
        }
    }
