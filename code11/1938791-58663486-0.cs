    public class Fruit
    {
        public string Day { get; set; }
        public string Name { get; set; }
        public string Kind { get; set; }
        public string Price { get; set; }
    }
    public class FruitReferencePrice
    {
        public string Name { get; set; }
        public string Kind { get; set; }
        public string Reference_Price { get; set; }
    }
    public class FruitFinal
    {
        public string Day { get; set; }
        public string Name { get; set; }
        public string Kind { get; set; }
        public string Price { get; set; }
        public string ReferencePrice { get; set; }
        public override string ToString()
        {
            return $"Day={Day},Name={Name},Kind={Kind},Price={Price},Reference_Price={ReferencePrice}";
        }
    }
