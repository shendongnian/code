    public abstract class abc
    {
        public virtual void test()
        {
        }
    }
    public class def : abc
    {
            // ignore test(), this is concrete class which can be initialized
            // test method is not needed for this class
    }
    public class ghi : def
    {
        public override void test()
        {
            // force test method implementation here
        }
    }
    
