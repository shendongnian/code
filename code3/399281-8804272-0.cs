    public abstract class Container
    {
        public abstract string IdType {get;}
    }
 
    public class SuperContainerB: Container
    {
        public readonly string IdType { get { return "B"; } }
    }
