    public class MyRecord {
        public int VideoId { get; set; }
    }
    
    public static async IAsyncEnumerable<MyRecord> GetRecordsAsync(string connectionString, SqlParameter[] parameters, string commandText, [EnumeratorCancellation]CancellationToken cancellationToken)
    {
        ...
                        yield return new MyRecord {
                            VideoId = reader["VideoID"]
                        }
        ...
    }
