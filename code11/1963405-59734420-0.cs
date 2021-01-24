c#
if(name != null)
{
  return new OkObjectResult($"Hello, {name}");
}
else
{
  return new BadRequestObjectResult("Please pass a name on the query string or in the request body");
}
...casting would not be necessary.
