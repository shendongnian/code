`csharp
public class ProductDTO
{
    public int ProductId { get; set; }
    public string Name{ get; set; }
}
`
You'll need to do :
`javascript
f.append('ProductDto.ProductId', objectToSend.productId );
f.append('ProductDto.Name', objectToSend.name);
`
Another solution is to use a string in your model, and deserialize the DTO yourself :
`csharp
public class ProductFile
{
   public IFormFile File { get; set; }
   public string ProductDto { get; set; } 
}
[HttpPost]
public async Task<IActionResult> Post([FromForm]ProductFile file)
{
    var productDto = JsonConvert.DeserializeObject<ProductDTO>(file.ProductDto);
}
`
