[HttpGet]
[Route("GetCollection")]
public IActionResult GetCollection(string testCode)
{
    List<string> retval = ...get a string list
    return Ok(retval);
}
**Edit**
It looks like this is missing in the `Configure(IApplicationBuilder app, IWebHostEnvironment env)` method:
app.UseMvc();
