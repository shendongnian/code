    public class Item
    {
        public string ItemCode { get; set; }
        public string Cost { get; set; }
        public override string ToString()
        {
            return "ItemCode : " + ItemCode + ", Cost : " + Cost;
        }
    }
