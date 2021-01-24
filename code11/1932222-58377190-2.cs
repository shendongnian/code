    class ProductComparer : IEqualityComparer<Product>  
    {
                public bool Equals(Product x, Product y) {
                    if (Object.ReferenceEquals(x, y)) return true;
    
                    if (Object.ReferenceEquals(x, null) || Object.ReferenceEquals(y, null))
                        return false;
    
                    return x.Make == y.Make && x.Model == y.Model;
                }
                public int GetHashCode(Product product) {
                    if (Object.ReferenceEquals(product, null)) return 0;
                    int hashProductName = product.Make == null ? 0 : product.Make.GetHashCode();
                    int hashProductCode = product.Model.GetHashCode();
                    return hashProductName ^ hashProductCode;
                }
     }
    **The Distinct operator has an overload method that lets you pass an instance of IEqualityComparer.** So for this approach we created a class “ProductComparer” that implements the IEqualityCompaper. Here’s the code to use it:
    
    if (!IsPostBack) {  
                    GridView1.DataSource = GetProducts()
                                           .Distinct(new ProductComparer());
                    GridView1.DataBind();
    }
