    public class DomainLayer
    {
        public IEnumerable<ProductDTO> GetProductsByEntityOptions(ODataQueryOptions<ProductDTO> options)
        {
             var filter = options.GetFilter();
             // Here the type of filter variable is Expression<Func<ProductDTO, bool>> as desired
             // The rest ...
        }
    }
