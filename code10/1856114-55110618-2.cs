var products = new List<Product>();
...
while (!lastuserinput.Equals("exit"))
{    
    var productName = Console.ReadLine(); 
    if (products.Any(product=>product.Name.Equals(productName))
    {
       Console.WriteLine("product already exists");
       continue;
    }
    ...
    productList.Add(new Product
    {
        ...
        Name = productName,
        ...
    };
...
}
