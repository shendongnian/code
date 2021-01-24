    public **partial class** ProductInfoes {
    var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<AuthorModel, AuthorDTO>();
            });
    IMapper iMapper = config.CreateMapper();
    
            public ProductDetails Map()
            {
                return iMapper.Map<ProductInfoes , ProductDetails>(this);
            }
    
    }
