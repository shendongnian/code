    class Program
    {
        static void Main(string[] args)
        {
            Vehicle v = new Vehicle();
            Car c = new Car();
            Console.WriteLine("Testing Vehicle base output");
            v.PrintInfo();
            Console.WriteLine("Testing Car inherited output");
            c.PrintInfo();
            return;
        }
    }
    class Vehicle
    {
        public virtual string MyTypeName() { return "Vehicle"; }
        public void PrintInfo()
        {
            Console.WriteLine(string.Format("Type: {0}", this.MyTypeName()));
        }
    }
    class Car : Vehicle
    {
        public override string MyTypeName() { return "Car"; }
    }
