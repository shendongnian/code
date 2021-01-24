c#
public class UserController : ODataController
{
/*...*/
    [HttpPost]
    public async Task<IHttpActionResult> Post([FromBody] User user)
    {
        var results = await _userService.AddUser(user);
        return Ok(results);
    }
/*...*/
