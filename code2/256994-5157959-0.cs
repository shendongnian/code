    public abstract class Task
    {
        public virtual string Description { get { return "default description"; } }
    }
    public class Walk : Task
    {
        public virtual string Description { get { return "Do walk"; } }
    }
