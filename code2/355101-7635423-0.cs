    using System;
    using System.IO;
    using System.Linq;
    
    class Sample {
        static void Main(){
            string[] data = File.ReadAllLines("data.txt");
            double sum = data.Select( x => {double v ;Double.TryParse(x, out v);return v;}).Sum();
            Console.WriteLine("sum:{0}", sum);
        }
    }
