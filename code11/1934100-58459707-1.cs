    class Sandwich
    {
        public string Name { get; set; }
        public string Meat { get; set; }
        public int TomatoSlices { get; set; }
        public Sandwich()
        {
            Name = "Tony";
            Meat = "None";
            TomatoSlices = 1;
        }
        public override string ToString()
        {
            return $"This sandwich named {Name} " +
                   $"has {Meat} meat and {TomatoSlices} slices of " +
                   $"tomato, for a total cost of {ComputerPrice()}";
             // Or just return the price if that's what you want instead:
             // return ComputerPrice().ToString();
        }
        public decimal ComputerPrice()
        {
            return 4M + 0.5M * TomatoSlices;
        }
    }
