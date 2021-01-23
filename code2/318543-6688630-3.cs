    public class A
    {
        public string GetName() { return "A"; }
    }
    
    public class B : A
    {
        // this method overrides the original
        public new string GetName() { return "B"; }
    }
    
