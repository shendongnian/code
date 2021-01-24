    public interface IInterfaceA { }
    public interface IInterfaceB : IInterfaceA { }
    public static class MyExtensions {
        public static void Print(this IInterfaceA a) => Console.WriteLine("A");
        public static void Print(this IInterfaceB b) => Console.WriteLine("B");
    }
    public class AB: IInterfaceA, IInterfaceB { }
    public class BA: IInterfaceB, IInterfaceA { }
    public partial class Program
    {
        static void Main(string[] args)
        {
            new AB().Print(); // B
            new BA().Print(); // B
        }
    }
