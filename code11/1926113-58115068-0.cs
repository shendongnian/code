csharp
public class ProductType
{
    public int Id {get;set;}
    public string Name { get; set; } = "";
    public virtual ICollection<Product> Products { get; set; }
}
public class Product
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public int ProductTypeId { get; set; }
    public virtual ProductType ProductType { get; set; }
}
They will be 2 type of GraphQL
csharp
public class ProductObject : ObjectGraphType<Product>
{
    private readonly IProductService product;
    public ProductObject(IProductService p)
    {
        product = p;
        Field(f => f.Id);
        Field(f => f.Name);
        FieldAsync<ProductTypeObject>("type",
            resolve: async context => await product.GetProductType(context.Source.Id));
    }
}
public class ProductTypeObject: ObjectGraphType<ProductType>
{
    private readonly IProductTypeService productType;
    public ProductTypeObject(IProductTypeService pT)
    {
        productType = pT;
        Field(f => f.Name);
        FieldAsync<ListGraphType<ProductObject>>("products",
            resolve: async context => await productType.GetProductsOfType(context.Source.Id));
    }
}
Explain it:
**IProductTypeService** and **IProductService** use to get data
**productType.GetProductsOfType(context.Source.Id)** will return **ICollection<Product>**
**await product.GetProductType(context.Source.Id)** will return **ProductType**
So you want to query 1 product type has many products it would be:
json
query getProductTypes {
   productTypes{
        id,
        name,
        products {
             id,
             name
        }        
   }
}
Hope it helps
