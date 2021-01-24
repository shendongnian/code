    public class Order
        {
            public int Id { get; set; }
            [Required]
            public string Name { get; set; }
            [Required]
            public DateTime Date { get; set; }
        }
