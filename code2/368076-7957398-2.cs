    public class Car
    {
        private int _maxSpeed = 200;
        public int MaxSpeed
        {
            get { return _maxSpeed; }
            private set { _maxSpeed = value; }
        }
    }
    
    public class Ferrari : Car
    {
        public Ferrari()
        {
            // Constructor 
            this.MaxSpeed = 250;
        }
    }
    
    // client code
    public void DoStuff()
    {
       Car ferrari = new Ferrari();
       Console.WriteLine( ferrari.MaxSpeed );
    }
