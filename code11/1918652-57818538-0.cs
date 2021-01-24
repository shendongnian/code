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
