    class Program
    {
    
        static void Main(string[] args)
        {
            var aList = (from item in Enumerable.Range(1, 10)
                            select new A { Z1 = item, Z2 = item * 2 }).ToList();
    
            var bList = (from item in Enumerable.Range(10, 100)
                         select new B { J5 = item, J6 = item / 2 }).ToList();
    
            var intersect = (from a in aList
                             join b in bList
                                on a.Z2 equals b.J6
                             select new { A = a, B = b }).ToList();
    
            foreach (var item in intersect)
            {
                Console.WriteLine("A:{{{0}}}, B:{{{1}}}", item.A, item.B);
            }
        }
    }
    
    public class A
    {
        public int Z1 { get; set; }
    
        public int Z2 { get; set; }
    
        // other fields and properties
    
        public override string ToString()
        {
            return string.Format("Z1={0}, Z2={1}", Z1, Z2);
        }
    }
    
    public class B
    {
        public int J5 { get; set; }
    
        public int J6 { get; set; }
    
        // other fields and properties
    
        public override string ToString()
        {
            return string.Format("J5={0}, J6={1}", J5, J6);
        }
    }
