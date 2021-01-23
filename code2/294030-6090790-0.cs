    void Main()
    {
        Ba instance = new Ba();
        instance.UseB();
    }
    
    public class Aa
    {
        public void UseB()
        {
            Ab instance = CreateB();   // <-- call factory method instead of new
            instance.Test();
        }
        
        public virtual Ab CreateB()
        {
            return new Ab();
        }
    }
    
    public class Ab
    {
        public virtual void Test()
        {
            Debug.WriteLine("A.b.Test");
        }
    }
    
    public class Ba : Aa
    {
        public override Ab CreateB()   // <-- it still returns type "Ab"
        {
            return new Bb();           // <-- just create an instance of Bb instead
        }
    }
    
    public class Bb : Ab
    {
        public override void Test()
        {
            Debug.WriteLine("B.b.Test");
        }
    }
