    // This interface takes two ints, returns one int
    public interface IBinaryOperation
    {
        int Execute(int x, int y);
        string Name { get; }
    }
    
    public class Add : IBinaryOperation
    {
        public int Execute(int x, int y) { return x + y; }
        public string Name { get { return "Add"; } }
    }
    
    public class Multiply : IBinaryOperation
    {
        public int Execute(int x, int y) { return x * y; }
        public string Name { get { return "Multiply"; } }
    }
