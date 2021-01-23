    public class Overloaded
    {
        public void ComplexOverloadResolution(params string[] somethings)
        {
            Console.WriteLine("Normal Winner");
        }
        public void ComplexOverloadResolution<M>(M something)
        {
            Console.WriteLine("Confused");
        }
        public void ComplexOverloadResolution(string something, object somethingElse = null)
        {
            Console.WriteLine("Added Later");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Overloaded a = new Overloaded();
            a.ComplexOverloadResolution(something:"asd");
        }
    }
