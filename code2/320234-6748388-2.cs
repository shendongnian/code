    public abstract class abc
    {
    }
    public abstract class lmn : abc
    {
     public abstract void Test();
    }
    public class def : abc
    {
        // ignore test(), this is concrete class which can be initialized
        // test method is not needed for this class
    }
    public class ghi : lmn
    {
     public override void test()
     {
        // force test method implementation here
     }
