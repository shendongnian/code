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
Type casting is necessary on the line of code you have in your question because of its use of the ternary operator (e.g. `a ? b : c`).  When using a ternary operator, both elements after the predicate (b and c) must share a type in common.  `OkObjectResult` and `BadRequestObjectResult` are two different types, so without the cast, this is unacceptable.
However, they both inherit from `ActionResult`.  By casting `OkObjectResult` to `ActionResult`, the `BadRequestObjectResult` element becomes acceptable, because it too is of type `ActionResult`.
