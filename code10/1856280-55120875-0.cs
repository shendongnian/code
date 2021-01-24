    public class ProductDTO
    {
        public string Name { get; set; }
        public string Price{ get; set; }
    }
    
      public List<ProductDTO> GetNameAndPrice()
        {
            using (EtradeContext db= new EtradeContext())
            {
    		return (from p in db.prdcts
                where p.name == "emre"
                select new ProductDTO { Name = p.name,Price = p.price }).ToList();
            }
        }
