        public class ProductsConverter : ITypeConverter<List<Product>, List<ProductDto>>
        {
            public List<ProductDto> Convert(List<Product> source, List<ProductDto> destination, ResolutionContext context)
            {
                return source.GroupBy(p => p.Name)
                            .Select(r => new ProductDto
                            {
                                Name = r.Key,
                                Prices =  source.Where(pp => pp.Name == r.Key)
                                                            .Select(rr => new PriceDto
                                                            {
                                                                Price = rr.Price,
                                                                Weight = rr.Weight
                                                            })
                            }).ToList();
            }
        }
