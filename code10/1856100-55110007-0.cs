    const String sql = @"
        ALTER INDEX PK_Employee_BusinessEntityID ON HumanResources.Employee REBUILD;
    ";
    using( StringWriter log = new StringWriter() )
    using( SqlConnection c = new SqlConnection( connectionString ) )
    using( SqlCommand cmd = c.CreateCommand() )
    {
        c.InfoMessage += ( s, e ) => log.WriteLine( e.Message );
        await c.OpenAsync().ConfigureAwait(false);
        cmd.CommandText = sql;
        await cmd.ExecuteNonQueryAsync().ConfigureAwait(false);
        MessageBox.Show( "Done!\r\n" + log.ToString() );
    }
