c#
// ActionsDetails actionsdetails = new ActionsDetails(); // Move this...
foreach (var actionname in input.ActionDetails)
{
    ActionsDetails actionsdetails = new ActionsDetails(); // ...here
    actionsdetails.ActionName = actionname.ActionName;
    actionsdetails.Description = actionname.Description;
    actionsdetails.ActionId = actionid;
    await _actionmanager.CreateActionsDetailsAsync(actionsdetails);
}
Related: [MapTo() inside of LINQ returning multiple iterations of same data](https://stackoverflow.com/q/55145922/8601760)
# AutoMapper
Another way is to leverage on ABP's [Object To Object Mapping](https://aspnetboilerplate.com/Pages/Documents/Object-To-Object-Mapping).
Configuration:
c#
[AutoMapTo(Actions)] // Add this
public class CreateActionDto
{
    [Required]
    public string DeviceId { get; set; }       
 // public ICollection<ActionsDetailsDto> ActionDetails { get; set; } // Rename this
    public ICollection<ActionsDetailsDto> ActionsDetails { get; set; }
}
[AutoMapTo(ActionsDetails)] // Add this
public class ActionsDetailsDto
{
    // ...
}
Usage:
c#
public async Task CreateActions(CreateActionDto input)
{
    Actions actions = new Actions();
    MapToEntity(input, actions);
    long actionId = await _actionmanager.CreateActionsAsync(actions);
}
private void MapToEntity(CreateActionDto actionsdto, Actions actions)
{
    _objectMapper.Map(actionsdto, actions);
}
