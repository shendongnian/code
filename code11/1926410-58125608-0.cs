    public class Automobile
    {
        private string maker;
        private string model;
        private double weight;
        private string color;
        private double gasTankCapacity;
        private double gasTankLevel;
        private double mpg;
    
        public Automobile()
        {
            maker = "Toyota";
            System.Console.WriteLine("ARG 0");
        }
    
        public Automobile(string maker)
        {
            this.maker = maker;
            System.Console.WriteLine("Arg 1");
        }
    
        public Automobile(string maker, string model): this(maker)
        {        
            this.model = model;
            System.Console.WriteLine("Arg 2");
        }
    
        public Automobile(string maker, string model, double weight) : this(maker, model)
        {
            this.weight = weight;
            System.Console.WriteLine("Arg 3");
        }
    
        public Automobile(string maker, string model, double weight, string color) : this(maker, model, weight)
        {
            this.color = color;
            System.Console.WriteLine("Arg 4");
        }
    
        public Automobile(string maker, string model, double weight, string color, double gasTankCapacity) : this(maker, model, weight, color)
        {
            this.gasTankCapacity = gasTankCapacity;
            System.Console.WriteLine("Arg 5");
        }
    
        public Automobile(string maker, string model, double weight, string color, double gasTankCapacity, double gasTankLevel) : this(maker, model, weight, color, gasTankCapacity)
        {
            this.gasTankLevel = gasTankLevel;
            System.Console.WriteLine("Arg 6");
        }
    
        public Automobile(string maker, string model, double weight, string color, double gasTankCapacity, double gasTankLevel, double mpg) : this(maker, model, weight, color, gasTankCapacity, gasTankLevel)
        {
            this.mpg = mpg;
            System.Console.WriteLine("Arg 7");
        }
    }
