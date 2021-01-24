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
asycn Task DoMyTransfer() 
{
  foreach(var buffer in TransferDocument(1, 10000)) {
    await moveBytes(buffer)
  }
}
