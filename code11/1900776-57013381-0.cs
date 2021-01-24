    //-------------------- Custom class Point --------------------
    class Point
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
        public Point(double x, double y, double z) { this.X = x; this.Y = y; this.Z = z; }
    }
    //-------------------- Main program --------------------
    class Program
    {
        static void Main(string[] args)
        {
            //ArrayList of different objects
            ArrayList arrlist = new ArrayList{
                new ArrayList { 1, "one" ,new Point(1.0,1.0,1.0)},
                new ArrayList { "two", 2,new Point(2.0,2.0,2.0) },
                new ArrayList { new Point(3.0,3.0,3.0), "three",3}
            };
            readData(arrlist);
            Console.ReadLine();
        }
        //-------------------- readData() function definition --------------------
        public static void readData(ArrayList arlst)
        {
            foreach (ArrayList l in arlst)
            {
                foreach (object item in l)
                {
                    Console.WriteLine($"... {item.ToString()} ...");
                }
            }
        }
    }
