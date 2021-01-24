    public class SuppliersProfile: Profile
    {
        public SuppliersProfile()
        {
    
         // ignore Supplier reference from Product when accessing each Product 
            field from the ICollection product
            CreateMap<Product, ProductDTO>()
                .ForMember(x => x.Supplier, c => c.Ignore());
            CreateMap<Supplier, SupplierDTO>().Include<Product, ProductDTO>();
                .ReverseMap();
    
        }
    }
