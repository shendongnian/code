    public class Vehicle
    {
        public string VRM; 
    }
    class Program
    {
        static void Main(string[] args)
        {
            var Reg = new Vehicle { VRM = "LP65 UGT" };
            var writer = new System.Xml.Serialization.XmlSerializer(typeof(Vehicle));
            var wfile = new System.IO.StreamWriter(@"C:\Myexample\NewVehicle.xml");
            writer.Serialize(wfile, Reg);
            wfile.Close();
            Console.WriteLine("Vehicle Reg is now written in xml format ");
            Console.ReadKey();
           
        }
    }
