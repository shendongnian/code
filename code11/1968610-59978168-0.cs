public class ApiCallException : Exception
{
    public APiCallException(int statusCode, ...)
    {
        ApiStatusCode = statusCode;
    }
    int ApiStatusCode { get; }
    ...
}
and copy over the status code from your API result, and then throw the exception.
var response = await httpClient.SendAsync(request); //call second API
if (!response.IsSuccessStatusCode)
{   
    var content = await response.Content.ReadAsStringAsync();
    throw new ApiCallException(500, content); 
}
You can then register an exception filter to deal with the result when calling `AddMvc`.
    services.AddMvc(options => options.Filters.Add<ExceptionFilter>());
where `ExceptionFilter` could be something like
    public class ExceptionFilter : IExceptionFilter
    {
        // ...
        public void OnException(ExceptionContext context)
        {
            if (context.Exception is ApiCallException ace)
            {
                var returnObject = CreateReturnObjectSomehow();
                context.Result = new ObjectResult(returnObject) { StatusCode = ace.StatusCode };
            }
            else
            {
                // do something else
            }
        }
    }
