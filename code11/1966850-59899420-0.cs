     public class Product
        {
            public string Name { get; set; }
            public string Company { get; set; }
            public double Price { get; set; }
            public double Discount { get; set; }
    
            public Product(string name, string company, double price, double discount)
            {
                Name = name;
                Company = company;
                Price = price;
                Discount = discount;
            }
        }
