[HttpPost("{templateName}"]  
public async Task<IActionResult> Generate(string templateName, [FromBody] object properties)
{
}
or even 
[HttpPost("/api/documents/{templateName}"]  
public async Task<IActionResult> Generate(string templateName, [FromBody] object properties)
{
}
