[HttpGet]
[Route("GetCollection")]
public IActionResult GetCollection(string testCode)
{
    List<string> retval = ...get a string list
    return Ok(retval);
}
