    void Main()
    {
        A a = (A)new B();
        GC.Collect();
        GC.WaitForPendingFinalizers();
        GC.Collect();
        GC.KeepAlive(a);
        Debug.WriteLine("Got here");
    }
    
    public interface A
    {
    }
    
    public class B : A
    {
        ~B()
        {
            Debug.WriteLine("B was finalized");
        }
    }
