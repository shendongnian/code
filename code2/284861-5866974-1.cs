    namespace Common {
    public abstract class AbsA
    {
        //...
    }
    public class MyFactory
    {
        public MyFactory()
        {
            //...
        }
        public AbsA getA()
        {
            AbsA a;
            if (condition)
                a = new Namespace1.A();
            else
                a = new Namespace2.A();
            return a;
        }
    }
    }
