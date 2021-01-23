    public class ItemType
    {
        public int Id { get; set; }
        public ItemType Parent { get; set; }
        public List<ItemType> Children; { get; set; }
        public double? DefaultDiscount { get; set; }
        public double? OverridenDiscount { get; set; }
        public double CalculatedDiscount
        {
            get
            {
                return (double)(OverridenDiscount ?? 
                                DefaultDiscount ?? 
                                (Parent != null ? Parent.CalculatedDiscount : 0));
            }
        }
    }
