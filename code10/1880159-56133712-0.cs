csharp
public class SomeQuery
{
    public string SomeParameter { get; set; }
    public int? SomeParameter2 { get; set; }
}
And then in controller just make something like that:
csharp
[HttpGet]
public IActionResult FindSomething([FromQuery] SomeQuery query)
{
    // Your implementation goes here..
    //then you can access query value using HttpContext.Request.Query
}
or using method params
csharp
[HttpGet]
public IActionResult FindSomething(string value1, string value2)
