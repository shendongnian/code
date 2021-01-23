    class Program
    {
        static void Main(string[] args)
        {
            float cos = Math.Cos(.25d).ToFloat();
    
            Console.WriteLine("cos(.25d) = {0}", cos);
    
            Console.ReadKey();
        }
    }
    
    public static class MathExtensions
    {
        public static float ToFloat(this double value)
        {
            return (float)value;
        }
    }
