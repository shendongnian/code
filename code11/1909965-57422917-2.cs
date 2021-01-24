class WebSiteChunkUploader : Stream
{
     private HttpClient _client = new HttpClient();
     public override bool CanWrite => true;
     public override bool CanRead => false;
     public override async Task WriteAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken) =>
         await _client.PostAsync("localhost", new ByteArrayContent(buffer,offset, count));
}
## Old Good IEnumerable
Unfortunately you cannot mix `yield return` of `IEnumerable` with `async/await`. But if you decide to read stream with a blocking api, eg `Read`, then you can rewrite it with old good `yield return`:
public IEnumerable<Tuple<byte[],int>> TransferDocument(int documentId, int maxChunkSize)
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
                while(var bytesRead = uploadDataStream.Read(buffer, 0, maxChunkSize)) > 0)
                   yield return Tuple(buffer, bytesRead);
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
In this case you won't have async IO with DB and fancy `Tasks`, but I suppose you'll need to throttle this upload operation anyway to do not overload DB with the connections.
