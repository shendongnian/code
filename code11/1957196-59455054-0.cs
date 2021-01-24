    using System;
    using System.Data;
    using System.Data.SqlClient;
    using Microsoft.SqlServer.Management.Common;
    
    class Example
    {
    
        static void Main(string[] args)
        {
                var script = @"
    IF (OBJECT_ID('sp_InsertDevice', 'P') IS NOT NULL) 
        DROP PROCEDURE sp_InsertDevice 
    GO
    CREATE PROCEDURE sp_InsertDevice
        @serialNumber nvarchar(8),
        @modelName nvarchar(40),
        @userId int
    AS
    BEGIN
        INSERT INTO Device (SerialNumber, ModelName, UserID)
        VALUES (@serialNumber, @modelName, @userId)
    
        SELECT CAST(SCOPE_IDENTITY() AS INT);
    END
    ";
            try
            {
                using (var connection = new SqlConnection("Data Source=YourServer;Integrated Security=SSPI;Initial Catalog=YourDatabase"))
                {
                    var serverConnection = new ServerConnection(connection);
                    connection.Open();
    
                    serverConnection.ExecuteNonQuery(script);
                }
            }
            catch
            {
                throw;
            }
        }
    }
