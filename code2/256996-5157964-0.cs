    public abstract class Task
    {
        public virtual string Description
        {
            get { return "default description"; }
        }
        ...
    }
    
    public class Walk : Task
    {
        public overrides string Description
        { 
            get { return "Do walk"; }
        }
        ...
    }
    
    public class Talk : Task
    {
        public overrides string Description
        { 
            get { return "Do talk"; }
        }
        ...
    }
