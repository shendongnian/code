        class Program
    {
        static void Main(string[] args)
        {
            Derived d = new Derived();
            Console.WriteLine(d.Serialize());
            Console.ReadLine();
        }
    }
    public abstract class Base
    {
        public int Property1 { get; set; }
    }
    public class Derived : Base
    {
        public int Property2 { get; set; }
    }
    public static class Extensions
    {
        public static string Serialize(this Base obj)
        {
            return System.Text.Json.JsonSerializer.Serialize((object)obj);
        }
    }
