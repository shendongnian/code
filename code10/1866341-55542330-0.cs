public class NotFoundResultFilterAttribute : ResultFilterAttribute
{
    public override void OnResultExecuting(ResultExecutingContext context)
    {
        if (context.Result is ObjectResult objectResult && objectResult.Value == null)
        {
            context.Result = new NotFoundResult();
        }
    }
}
Just apply it to your controller method
[HttpGet()]
[Route("Contracts/{id}")]
[NotFoundResult]
public async Task<IActionResult> Get(int id)
Make sure your Controller is decorated with the `ApiController` attribute.
