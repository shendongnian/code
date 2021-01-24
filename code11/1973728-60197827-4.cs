c#
// this example creates a reference loop
var p = new Product()
     { 
        ProductCategory = new ProductCategory() 
           { products = new List<Product>() }
     };
	p.ProductCategory.products.Add(p); // <- this create the loop
	var x = JsonSerializer.Serialize(p); // A possible object cycle was detected ...
You can not handle the reference loop situation in the new `System.Text.Json` yet (netcore 3.1.1) unless you completely ignore a reference and its not a good idea always. (using `[JsonIgnore]` attribute)
but you have two options to fix this. 
1. you can use [`Newtonsoft.Json`][1] in your project instead of `System.Text.Json` (i linked an article for you)
2. Download the `System.Text.Json` preview package version `5.0.0-alpha.1.20071.1` from dotnet5 gallery (through Visual Studio's NuGet client):
option 1 usage:
c#
services.AddMvc()
     .AddNewtonsoftJson(
          options => {
           options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore; 
      });
option 2 usage: 
c#
// for manual serializer
var options = new JsonSerializerOptions
{
    ReferenceHandling = ReferenceHandling.Preserve
};
string json = JsonSerializer.Serialize(objectWithLoops, options);
// .... for asp.net core 3.1 (globaly)
 services.AddMvc()
  .AddJsonOptions(o => {
     o.ReferenceHandling = ReferenceHandling.Preserve  
            });
these serializers have `ReferenceLoopHandling` feature. 
<hr/>
but if you wanna just ignore one reference use `[JsonIgnore]` on one of these properties. but it causes null result on your API response for that field.
c#
public class Product
{
	public int Id { get; set; }
	public string Name { get; set; }
	public string ProductText { get; set; }
	
	public int ProductCategoryId { get; set; }
	// [JsonIgnore] HERE or
	public virtual ProductCategory ProductCategory { get; set; }
}
public class ProductCategory
{
	public int Id { get; set; }
	// [JsonIgnore] or HERE
 	public ICollection<Product> products {get;set;}
}
  [1]: https://dotnetcoretutorials.com/2019/12/19/using-newtonsoft-json-in-net-core-3-projects/
