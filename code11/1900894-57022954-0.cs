public class NotFoundMiddleware
{
    private readonly RequestDelegate _next;
    public NotFoundMiddleware(RequestDelegate next)
    {
        _next = next;
    }
    public async Task Invoke(HttpContext context)
    {
        // Actual processing code goes here
        context.Response.StatusCode = StatusCodes.Status200OK;
        await context.Response.WriteAsync("Hello, world!");
    }
}
Then register in in Startup class **after** MVC middleware so it handles all requests not served by MVC (exactly the case of not found controller)
app.UseMvc();
app.UseMiddleware<NotFoundMiddleware>();
Now `http://localhost:5000/nonExistingController/nonExistingAction` gives us `Hello world` response.
**P.S.** If you really want to use controller you can also redirect from this middleware to `DefaultController` with `Moved Permanently` although it would not be very efficient
