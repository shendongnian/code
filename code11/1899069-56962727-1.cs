        public class ModelProfile: Profile
        {
            public ModelProfile()
            {
                CreateMap<List<Product>, List<ProductDto>>()
                    .ConvertUsing<ProductsConverter>();
            }
        }
