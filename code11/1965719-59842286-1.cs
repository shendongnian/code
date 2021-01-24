    class Program
    {
        static void Main(string[] args)
        {
            Pizza<Pasta> ao = new Pizza<Pasta>();
            ((Pasta)ao).MyProperty = 10;
        }
    }
    public interface IPizza<T>
    {
    }
    public class Pizza<T> : IPizza<T>
    {
    }
    public class Pasta
    {
        public int MyProperty { get; set; }
    }
