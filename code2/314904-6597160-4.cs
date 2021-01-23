    private IExecuteResult Execute(Expression query, SqlProvider.QueryInfo queryInfo, IObjectReaderFactory factory, object[] parentArgs, object[] userArgs, ICompiledSubQuery[] subQueries, object lastResult)
    {
      this.InitializeProviderMode();
      DbConnection dbConnection = this.conManager.UseConnection((IConnectionUser) this);
      try
      {
        DbCommand command = dbConnection.CreateCommand();
        command.CommandText = queryInfo.CommandText;
        command.Transaction = this.conManager.Transaction;
        command.CommandTimeout = this.commandTimeout;
        this.AssignParameters(command, queryInfo.Parameters, userArgs, lastResult);
        this.LogCommand(this.log, command);
        ++this.queryCount;
    ...
      }
      finally
      {
        this.conManager.ReleaseConnection((IConnectionUser) this);
      }
    }
