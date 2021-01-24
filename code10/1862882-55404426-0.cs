csharp
List<Product> products = new List<Product>();
while (getInput("Item Name(enter 0 to stop): ", out var name)
        && getInput("Item Price(enter 0 to stop): ", out var price)
        && getInput("Quantity(enter 0 to stop): ", out var quantity))
{
    products.Add(new Product
    {
        Name = name,
        Price = Convert.ToDecimal(price),
        Quantity = Convert.ToInt32(quantity)
    });
}
decimal totalPrice = products.Sum(p => p.Price);
Console.WriteLine(totalPrice);
