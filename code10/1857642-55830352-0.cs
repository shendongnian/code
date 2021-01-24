using System;
using System.Linq;
using MongoDAL;
namespace Example
{
    class Measurement : Entity
    {
        public int s { get; set; }
        public int[] p { get; set; }
        public int dt { get; set; }
        public int ml { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            new DB("measurements");
            var measurement1 = new Measurement
            {
                s = 10,
                ml = 20,
                dt = 100,
                p = new int[] { 1, 2, 3, 4, 5 }
            };
            var measurement2 = new Measurement
            {
                s = 11,
                ml = 22,
                dt = 200,
                p = new int[] { 1, 2, 3, 4, 5 }
            };
            measurement1.Save();
            measurement2.Save();
            var result = (from m in DB.Collection<Measurement>()
                          where m.dt > 100
                          select m).ToArray();
            
            Console.ReadKey();
        }
    }
}
