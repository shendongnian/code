public IEnumerable<byte[]> TransferDocument(int documentId, int maxChunkSize)
{
    string sql = "SELECT Data FROM Document WHERE Id = @Id";
    var buffer = new byte[maxChunkSize];
    using (SqlConnection connection = new SqlConnection(ConnectionString))
    {
        connection.Open();
        using (SqlCommand command = new SqlCommand(sql, connection))
        {
            command.Parameters.AddWithValue("@Id", documentId);
            using (SqlDataReader reader = command.ExecuteReader(CommandBehavior.SequentialAccess))
            using (Stream uploadDataStream = reader.GetStream(0))
            {
                var readData = () => uploadDataStream.Read(buffer, 0, maxChunkSize);
                for(var bytesRead = readData(); bytesRead > 0; bytesRead = readData())
                   yield return buffer.Take(bytesRead).ToArray(); // FIX ME!
            }
        }
    }
}
...
async Task DoMyTransfer() 
{
  foreach(var buffer in TransferDocument(1, 10000)) {
    await moveBytes(buffer)
  }
}
In this case you won't have async IO with DB, but I suppose you'll need to throttle this upload operation anyway to do not overload DB with the connections.
If you can get a stream where you need to upload, then you can use [CopyToAsync](https://docs.microsoft.com/en-us/dotnet/api/system.io.stream.copytoasync?view=netframework-4.8#System_IO_Stream_CopyToAsync_System_IO_Stream_System_Int32_). But I assume that each chunk will be uploaded in the individual request. If so, you may introduce a component which will quack as a `Stream` but will actually upload content to the website:
class WebSiteChunkUploadStrean : Stream
{
     private HttpClient _client = new HttpClient();
     public override bool CanWrite => true;
     public override async Task WriteAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken) =>
         await _client.PostAsync("localhost", new ByteArrayContent(buffer,offset, count));
}
