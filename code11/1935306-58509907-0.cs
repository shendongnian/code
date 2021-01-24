    class Transportation
        {
            private string name; //name company
            private double cost; //unit price
            private double weight; // Shipping Weight
    
            public Transportation(string name, double cost, double weight)
            {
                Name = name;
                Cost = cost;
                Weight = weight;
            }
            public Transportation()
            {
                Name = "none";
                Cost = 0;
                Weight = 0;
            }
            public double Cost { get => cost; set => cost = value; }
            public string Name { get => name; set => name = value; }
            public double Weight { get => weight; set => weight = value; }
        }
        class Program
        {
            static void Main(string[] args)
            {
                Transportation company = new Transportation("LG", 24.05, 1000);
    
                Transportation[] transportations = new Transportation[]
                {
                    new Transportation("LG", 24.05, 1000),
                    new Transportation("SAMSUNG", 30.00, 1010)
                };
            }
        }
