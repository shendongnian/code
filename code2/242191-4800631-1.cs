    public class CustomerSales
    {
        public CustomerSales(string name, params int[] sales)
        {
            Name = name;
            Sales = sales;
        }
        [Required]
        public string Name { get; set; }
        [Required]
        public int[] Sales { get; set; }
    }
