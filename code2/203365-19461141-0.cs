        namespace XXX.Models
        {
            public class Product
            {
                public int ProductID { get; set; }
                public string ProductName { get; set; }
                public string ProductDescription { get; set; }
        
                public string ProductImage
                {
                    get { return ProductName.Replace(" ", string.Empty) + ".jpg"; }
                }
            }
        }
