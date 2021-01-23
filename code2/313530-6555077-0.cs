    public class Foo
    {
        int[] value = new int[100];
        ~Foo()
        {
            GC.ReRegisterForFinalize(this);
        }
    }
