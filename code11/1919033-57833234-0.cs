    this.CreateMap<ShopifySharp.ProductVariant, ShopifyVariant>().ForMember(o => o.Id, o => o.MapFrom(f => f.Id))
    .ForMember(o => o.ProductId, o => o.MapFrom(f => f.ProductId))
    .ForMember(o => o.VariantName, o => o.MapFrom(f => f.Title))
    .ForMember(o => o.Barcode, o => o.MapFrom(f => f.Barcode))
    .ForMember(o => o.Price, o => o.MapFrom(f => f.Price))
    .ForMember(o => o.Grams, o => o.MapFrom(f => f.Grams))
    .ForMember(o => o.Taxable, o => o.MapFrom(f => f.Taxable))
    .ForMember(o => o.Weight, o => o.MapFrom(f => f.Weight))
    .ForMember(o => o.WeightUnit, o => o.MapFrom(f => f.WeightUnit))
    .ForMember(o => o.SKU, o => o.MapFrom(f => f.SKU));
    
    this.CreateMap<ShopifySharp.Product, ShopifyVariant>().ForMember(o => o.ProductName, o => o.MapFrom(f => f.Title));
    this.CreateMap<IEnumerable<ShopifySharp.Product>, IEnumerable<ShopifyVariant>>()
    .ConvertUsing<ShopifyProductsToVariantsCollectionTypeConverter>();
    internal class ShopifyProductsToVariantsCollectionTypeConverter : ITypeConverter<IEnumerable<ShopifySharp.Product>, IEnumerable<ShopifyVariant>>
    {
        public IEnumerable<ShopifyVariant> Convert(IEnumerable<ShopifySharp.Product> source, IEnumerable<ShopifyVariant> destination, ResolutionContext context)
        {
            var result = new List<ShopifyVariant>();
            foreach (var product in source)
            {
                foreach (var variant in product.Variants)
                {
                    var mappedVariant = context.Mapper.Map<ShopifyVariant>(variant);
                    context.Mapper.Map(product, mappedVariant);
                    result.Add(mappedVariant);
                }
            }
    
            return result;
        }
    }
