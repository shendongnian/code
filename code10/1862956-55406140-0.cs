    class Program
    {
        static void Main(string[] args)
        {
            string inputString = Console.ReadLine();
            double[] hvValues = inputString.Split().Select(double.Parse).ToArray();
    
            double sinTest = hvValues[1];
            double sinV = Math.Sin(sinTest);
            double hypotenusan = hvValues[0] / sinV;
            Console.WriteLine(Math.Ceiling(hypotenusan));
        }
    }
