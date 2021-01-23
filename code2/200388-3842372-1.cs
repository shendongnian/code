    public class Program
    {
        static void Main(string[] args)
        {
            var o = new ViewAsHex();
            o.Value = 258986522;
            var xs = new XmlSerializer(typeof(ViewAsHex));
            
            var output = Console.OpenStandardOutput();
            xs.Serialize(output, o);
            Console.WriteLine();
            Console.WriteLine("Press enter to exit.");
            Console.ReadLine();
        }
    }
