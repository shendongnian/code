    public class Product
    {
        public int Id { get; set; }
        public string IdString 
        {
            get
            {
                return Id.ToString();
            }
        }
        public string Name { get; set; }
    }
