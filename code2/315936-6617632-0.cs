    using System.Linq;
    
     static void Main(string[] args)
        {
            List<double> list = new List<double>();
            list.Add(34.2);
            list.Add(234);
            Console.WriteLine(list.Sum());
    
            Dictionary<string, double> dictioanary = new Dictionary<string, double>();
            dictioanary.Add("a", 5.34);
            dictioanary.Add("b", 44);
    
            Console.WriteLine(dictioanary.Values.Sum()); // See?
            Console.ReadKey();
        }
