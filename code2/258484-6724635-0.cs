    public class VarbinaryStream : Stream  {
    private SqlConnection _Connection;
    private string _TableName;
    private string _BinaryColumn;
    private string _KeyColumn;
    private int _KeyValue;
    private long _Offset;
    private long _SQLReadPosition;
    public VarbinaryStream(
        string ConnectionString,
        string TableName,
        string BinaryColumn,
        string KeyColumn,
        int KeyValue)
    {
      // create own connection with the connection string.
      _Connection = new SqlConnection(ConnectionString);
      _TableName = TableName;
      _BinaryColumn = BinaryColumn;
      _KeyColumn = KeyColumn;
      _KeyValue = KeyValue;
    }
    public override void Write(byte[] buffer, int offset, int count)
    {
      var cts = new CancellationTokenSource();
      WriteAsync(buffer, offset, count, cts.Token).Wait(cts.Token);
    }
    // this method will be called as part of the Stream ímplementation when we try to write to our VarbinaryStream class.
    public override Task WriteAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
    {
      Task t = null;
      try
      {
        if (_Connection.State != ConnectionState.Open)
          _Connection.Open();
        if (_Offset == 0)
        {
          // for the first write we just send the bytes to the Column
          SqlCommand cmd = new SqlCommand(
                                      @"UPDATE [dbo].[" + _TableName + @"]
                                                SET [" + _BinaryColumn + @"] = @firstchunk 
                                            WHERE [" + _KeyColumn + "] = @id",
                                  _Connection);
          cmd.Parameters.Add(new SqlParameter("@firstchunk", buffer));
          cmd.Parameters.Add(new SqlParameter("@id", _KeyValue));
          t = cmd.ExecuteNonQueryAsync(cancellationToken);
          _Offset = count;
        }
        else
        {
          // for all updates after the first one we use the TSQL command .WRITE() to append the data in the database
          SqlCommand cmd = new SqlCommand(
                                  @"UPDATE [dbo].[" + _TableName + @"]
                                            SET [" + _BinaryColumn + @"].WRITE(@chunk, NULL, @length)
                                        WHERE [" + _KeyColumn + "] = @id",
                               _Connection);
          cmd.Parameters.Add(new SqlParameter("@chunk", buffer));
          cmd.Parameters.Add(new SqlParameter("@length", count));
          cmd.Parameters.Add(new SqlParameter("@id", _KeyValue));
          t = cmd.ExecuteNonQueryAsync(cancellationToken);
          _Offset += count;
        }
      }
      catch (Exception e)
      {
        // log errors here
      }
      return t;
    }
    private SqlDataReader sqlReader = null;
    private async Task<SqlDataReader> GetSqlReader()
    {
      if (sqlReader == null)
      {
        try
        {
          if (_Connection.State != ConnectionState.Open)
            await _Connection.OpenAsync();
          SqlCommand cmd = new SqlCommand(
                          @"SELECT TOP 1 [" + _BinaryColumn + @"]
                                FROM [dbo].[" + _TableName + @"]
                                WHERE [" + _KeyColumn + "] = @id",
                      _Connection);
          cmd.Parameters.Add(new SqlParameter("@id", _KeyValue));
          sqlReader = cmd.ExecuteReader(
              CommandBehavior.SequentialAccess |
              CommandBehavior.SingleResult |
              CommandBehavior.SingleRow |
              CommandBehavior.CloseConnection);
          await sqlReader.ReadAsync();
        }
        catch (Exception e)
        {
          // log errors here
        }
      }
      return sqlReader;
    }
    // this method will be called as part of the Stream ímplementation when we try to read from our VarbinaryStream class.
    public override int Read(byte[] buffer, int offset, int count)
    {
      var cts = new CancellationTokenSource();
      return ReadAsync(buffer, offset, count, cts.Token).Result;
    }
    public override Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
    {
      return Task.Factory.StartNew(() =>
        {
          try
          {
            long bytesRead = GetSqlReader().Result.GetBytes(0, _SQLReadPosition, buffer, offset, count);
            _SQLReadPosition += bytesRead;
            return (int)bytesRead;
          }
          catch (Exception e)
          {
            // log errors here
          }
          return -1;
        }, cancellationToken);
    }
    public override bool CanRead
    {
      get { return true; }
    }
    protected override void Dispose(bool disposing)
    {
      if (_Connection != null)
      {
        if (_Connection.State != ConnectionState.Closed)
          try { _Connection.Close(); }
          catch { }
        _Connection.Dispose();
      }
      base.Dispose(disposing);
    }
    #region unimplemented methods
    public override bool CanSeek
    {
      get { return false; }
    }
    public override bool CanWrite
    {
      get { return true; }
    }
    public override void Flush()
    {
      throw new NotImplementedException();
    }
    public override long Length
    {
      get { throw new NotImplementedException(); }
    }
    public override long Position
    {
      get
      {
        throw new NotImplementedException();
      }
      set
      {
        throw new NotImplementedException();
      }
    }
    public override long Seek(long offset, SeekOrigin origin)
    {
      throw new NotImplementedException();
    }
    public override void SetLength(long value)
    {
      throw new NotImplementedException();
    }
    #endregion unimplemented methods}
