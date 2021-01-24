C#
class Product{
    ...
    public decimal Price { get; set; } = 0;
    ....
}
Way 2: **syntactic sugar**:       
c#
<td>product.Price?.Value.ToString("N2") ?? ""</td>
