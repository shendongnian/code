csharp
public struct MyModel
{
    public int Value1 { get; set; }
    public int Value2 { get; set; }
    public IFormFile Files { get; set; }
}
[HttpPost("test_2")]
public async Task<IActionResult> Test2([FromForm]MyModel model) { return Ok(); }
Hope it helps
