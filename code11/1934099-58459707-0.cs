    class Sandwich
    {
        public string Name { get; set; } = "Tony";
        public string Meat { get; set; } = "None";
        public int TomatoSlices { get; set; } = 1;
        public decimal ComputerPrice()
        {
            return 4M + 0.5M * TomatoSlices;
        }
        public override string ToString()
        {
            return $"This sandwich named {Name} " +
                   $"has {Meat} meat and {TomatoSlices} slices of " +
                   $"tomato, for a total cost of {ComputerPrice()}";
             // Or just return the price if that's what you want instead:
             // return ComputerPrice().ToString();
        }
    }
