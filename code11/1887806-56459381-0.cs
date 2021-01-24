C#
public class FileCallbackResult : FileResult
{
    private Func<Stream, ActionContext, Task> _callback;
    public FileCallbackResult(MediaTypeHeaderValue contentType, Func<Stream, ActionContext, Task> callback)
        : base(contentType?.ToString())
    {
        if (callback == null)
            throw new ArgumentNullException(nameof(callback));
        _callback = callback;
    }
    public override Task ExecuteResultAsync(ActionContext context)
    {
        if (context == null)
            throw new ArgumentNullException(nameof(context));
        var executor = new FileCallbackResultExecutor(context.HttpContext.RequestServices.GetRequiredService<ILoggerFactory>());
        return executor.ExecuteAsync(context, this);
    }
    private sealed class FileCallbackResultExecutor : FileResultExecutorBase
    {
        public FileCallbackResultExecutor(ILoggerFactory loggerFactory)
            : base(CreateLogger<FileCallbackResultExecutor>(loggerFactory))
        {
        }
        public Task ExecuteAsync(ActionContext context, FileCallbackResult result)
        {
            SetHeadersAndLog(context, result, null);
            return result._callback(context.HttpContext.Response.Body, context);
        }
    }
}
Usage:
C#
[HttpGet("csv")]
public IActionResult GetCSV(long id)
{
  return new FileCallbackResult(new MediaTypeHeaderValue("text/csv"), async (outputStream, _) =>
  {
    var data = await GetData(id);
    var records = _csvGenerator.GenerateRecords(data); 
    var writer = new StreamWriter(outputStream);
    var csv = new CsvWriter(writer);
    csv.WriteRecords(stream, records);
    await writer.FlushAsync();
  })
  {
    FileDownloadName = "results.csv"
  };
}
Bear in mind that `FileCallbackResult` has the same limitations as `PushStreamContext`: that if an error occurs *in the callback*, the web server has no good way of notifying the client of that error. All you can do is propagate the exception, which will cause ASP.NET to clamp the connection shut early, so clients get a "connection unexpectedly closed" or "download aborted" error. This is because HTTP sends the error code *first*, in the header, before the body starts streaming.
  [1]: https://blog.stephencleary.com/2016/11/streaming-zip-on-aspnet-core.html
  [2]: https://github.com/StephenClearyExamples/AsyncDynamicZip/blob/cc09ad98f892f41b7eedf5e7adc1cf08b54a2492/Example/src/WebApplication/FileCallbackResult.cs
