csharp
[HttpGet]
public  FileStreamResult GetStreaming()
{
    var header = Request.Headers["Accept-Encoding"];
    System.Console.WriteLine(header);
    string connectionString = "Data Source=myPc\\SQLEXPRESS;Initial Catalog=dbo;Persist Security Info=True;User ID=sa;Password=admin";
    //----------------------
    SqlConnection connection = new SqlConnection(connectionString);
    connection.Open();
    SqlCommand command = new SqlCommand("exec getBlob", connection);
    SqlTransaction tran = connection.BeginTransaction(IsolationLevel.ReadCommitted);
    command.Transaction = tran;
    SqlDataReader reader = command.ExecuteReader(CommandBehavior.SequentialAccess)
    var blobStream = reader.GetStream(0);
            
    return new FileStreamResult(blobStream, "application/x-binary")
    {
         FileDownloadName = "your file name"
    };
}
