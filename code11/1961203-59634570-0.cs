    public class Realtor
    {
        public string Name { get; set; }
        public int PropertiesSold { get; set; }
        public override string ToString()
        {
            return $"Name: {Name}  Properties Sold: {PropertiesSold}";
        }
    }
