void Test()
{
    var mapper = new MapperConfiguration(cfg => { }).CreateMapper();
    var dictionary = new Dictionary<string, object>()
    {
        { "Id", 1 },
        { "Description", "test" }
    };
    var product = mapper.Map<Product>(dictionary);
    Assert.IsNotNull(product);
    Assert.AreEqual(product.Id, 1);
    Assert.AreEqual(product.Description, "test");
}
class Product
{
    public int Id { get; set; }
    public string Description { get; set; }
}
  [1]: http://docs.automapper.org/en/stable/Dynamic-and-ExpandoObject-Mapping.html
