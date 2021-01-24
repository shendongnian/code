    public class SuppliersProfile: Profile
    {
        public SuppliersProfile()
        {
    
         // ignore Supplier reference from Product when accessing each Product 
            field from the ICollection product
            CreateMap<Supplier, SupplierDTO>()
                .ForMember(x => x.Supplier, c => c.Ignore())
                .ReverseMap();
    
        }
    }
