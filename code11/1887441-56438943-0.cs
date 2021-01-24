    public  class AutoMapperConfig : Profile
     {
      public   AutoMapperConfig()
        {
        AutoMapper.Mapper.Initialize(cfg => {
           cfg.CreateMap<Product, ProductDTO>();
		   cfg.CreateMap<ProductType, ProductTypeDTO>();
            /* etc */
         });
         }
       }
