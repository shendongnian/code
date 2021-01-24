`
 public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string ProductText { get; set; }
    [JsonIgnore]
    public virtual ProductCategory ProductCategory { get; set; }
}
`
You probably don't need the ProductCategoryId field (depends if you are using EF and code first to define your DB)
