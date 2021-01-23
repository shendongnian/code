    public class A
    {
        public virtual void WriteLine(string toWrite) { Console.WriteLine(toWrite); }
    }
    
    public class B : A
    {
        public override void WriteLine(string toWrite) { Console.WriteLine(toWrite + " from B"); }
    }
