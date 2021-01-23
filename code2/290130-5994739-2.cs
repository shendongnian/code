    public interface IOperation
    {
        int GetResult(int a, int b);
    }
    public class Addition : IOperation
    {
        public int GetResult(int a, int b)
        {
             return a + b;
        }
    }
    public static void Main()
    {
        IOperation op = new Addition();
        Console.WriteLine(op.GetResult(1, 2));
    }
