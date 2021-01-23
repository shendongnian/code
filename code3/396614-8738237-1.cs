    public abstract class Base
    {
    ...
    }
    
    internal class Common : Base
    {
    ...
    }
    
    public class Instance
    {
        internal Instance(Common common)
        {
            ...
        }
    ...
    }
