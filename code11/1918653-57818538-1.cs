csharp
services.AddMvc(options => 
    {
        options.MaxValidationDepth = null;
    })
**EDIT**
As far as I can tell you need to add BindRequired to the frombody attribute to actually get it to behave as you expect.
This results in a method that looks like this:
csharp
public async Task<IActionResult> ValidateModelProperly([BindRequired, FromBody] RequestModel model)
{
    if (!ModelState.IsValid)
    {
        return BadRequest(ModelState);
    }
     return NoContent();
}
as opposed to:
csharp
public async Task<IActionResult> ValidateModelProperly([FromBody] RequestModel model)
{
    if (!ModelState.IsValid)
    {
        return BadRequest(ModelState);
    }
     return NoContent();
}
I hope this helps, if I misunderstood anything or if you see mistakes I made please let me know!
