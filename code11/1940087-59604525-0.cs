C#
var webApiModule = new WebApiModule("/api", ResponseSerializer.Json)
    .WithController<MyController>()
    .HandleUnhandledException(ExceptionHandler.DataResponseForException));
WebServerEmbedded = new EmbedIO.WebServer(
    opt => opt
        .WithUrlPrefix(url)
        .WithMode(HttpListenerMode.EmbedIO))
    .WithModule(webApiModule)
    .HandleHttpException(ExceptionHandler.DataResponseForHttpException);
C#
internal static class ExceptionHandler
{
    public static Task DataResponseForException(IHttpContext context, Exception exception)
    {
        // Replace ANY_VALID_STATUS CODE with, well, any valid status code.
        // Of course you can use different status codes according to, for example,
        // the type of exception.
        throw new HttpException(ANY_VALID_STATUS_CODE, exception.Message);
    }
    public static Task DataResponseForHttpException(IHttpContext context, IHttpException httpException)
        => ResponseSerializer.Json(context, httpException.Message);
}
