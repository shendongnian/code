public interface IStreamableDisposible : IDisposable
{
    public System.IO.Stream Stream { get; }
}
public class StreamableDisposible : IStreamableDisposible
{
    private readonly IDisposable toDisposeOf;
    public StreamableDisposible(System.IO.Stream stream, System.Data.Common.DbDataReader toDisposeOf)
    {
        Stream = stream ?? throw new ArgumentNullException(nameof(stream));
        this.toDisposeOf = toDisposeOf;
    }
    public System.IO.Stream Stream { get; set; }
    public void Dispose()
    {
        toDisposeOf?.Dispose();
    }
}
This is the new `ActionResult` class so that I can ensure that my disposable is cleaned up immediately after the stream is finished being used to execute the result.
public class DisposingFileStreamResult : FileStreamResult
{
    private readonly IStreamableDisposible streamableDisposible;
    public DisposingFileStreamResult(IStreamableDisposible streamableDisposible, string contentType)
        : base(streamableDisposible.Stream, contentType)
    {
        this.streamableDisposible = streamableDisposible ?? throw new ArgumentNullException(nameof(streamableDisposible));
    }
    public override void ExecuteResult(ActionContext context)
    {
        base.ExecuteResult(context);
        streamableDisposible.Dispose();
    }
    public override Task ExecuteResultAsync(ActionContext context)
    {
        return base.ExecuteResultAsync(context).ContinueWith(x => streamableDisposible.Dispose());
    }
}
This let me update my `GetDocumentStream()` method to be as follows
public StreamableDisposible GetDatabaseStream(Guid documentId)
{
    const string query = "SELECT DocumentData FROM tblDocuments WHERE DocumentId = @documentId AND DocumentData IS NOT NULL AND DATALENGTH(DocumentData) > 0";
    using var command = ((NHibernateData)Data).ManualCommand();
           
    command.CommandText = query;
    var parameter = command.CreateParameter();
    parameter.DbType = System.Data.DbType.Guid;
    parameter.ParameterName = "@documentId";
    parameter.Value = documentId;
    command.Parameters.Add(parameter);
    //Execute commmand with SequentialAccess to support streaming the data
    var reader = command.ExecuteReader(System.Data.CommandBehavior.SequentialAccess);
    if(reader.Read())
        return new StreamableDisposible(reader.GetStream(0), reader);
    else
    {
        reader.Dispose();
        return null;
    }
}
And my action now looks like this
public IActionResult Stream(Guid id, string contentType = "application/octet-stream") // Defaults to octet-stream when unspecified
{
    // Simple lookup by Id so that I can use it for the Name and ContentType below
    if(!(documentService.GetDocument(id)) is Document document) 
        return NotFound();
    var cd = new System.Net.Http.Headers.ContentDispositionHeaderValue("inline") {FileNameStar = document.DocumentName};
    Response.Headers.Add(Microsoft.Net.Http.Headers.HeaderNames.ContentDisposition, cd.ToString());
    var sd = var sd = documentService.GetDocumentStream(id);
    return new DisposingFileStreamResult(sd, document.ContentType ?? contentType);
}
I added checks to the SELECT statement to account for null data columns, or just null data length to eliminate having to have checks for the both `StreamableDisposable` and for the `Stream` itself being null, or just possibly no data, etc.
This is pretty much all of the code I ended up using.
