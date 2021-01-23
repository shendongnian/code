        class WebIdComparer : IEqualityComparer<Product>
        {
            public bool Equals(Product x, Product y)
            {
                return Equals(x.WebId, y.WebId);
            }
    
            public int GetHashCode(Product obj)
            {
                unchecked
                {
                    return obj.WebId.GetHashCode();
                }
            }
        }
    
        class UriComparer : IEqualityComparer<Product>
        {
            public bool Equals(Product x, Product y)
            {
                return Equals(x.Uri, y.Uri);
            }
    
            public int GetHashCode(Product obj)
            {
                unchecked
                {
                    return obj.Uri.GetHashCode();
                }
            }
        }
