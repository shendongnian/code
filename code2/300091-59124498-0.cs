    public class Product
    {
        public string ProductName { get; set; }
        public int Id { get; set; }
        public override bool Equals(object obj)
        {
            if (!(obj is Product))
            {
                return false;
            }
            var other = (Product)obj;
            return Id == other.Id;
        }
        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
