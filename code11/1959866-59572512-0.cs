public class CustomDto
{
    public SimpleJsonPatchDocument<Foo> Patch { get; set; }
    public JObject<Foo> Json { get; set; }
}
public IActionResult Patch(Guid id, [FromBody] CustomDto data)
{
   // TODO: Access properties of data
   // data.Patch
   // data.Json
   // etc.
}
 
