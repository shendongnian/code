    using (var conn = new SqlConnection(ConnectionString))
                {
                    String sql = @"SELECT NEXT VALUE FOR Test.CountBy1TestSequence";
    
                    var result = conn.ExecuteScalar<Int>(sql);
                    // Do whatever with the result    
                }
