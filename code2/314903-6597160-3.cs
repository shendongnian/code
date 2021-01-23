      public IExecuteResult Execute(IProvider provider, object[] arguments)
      {
        if (provider == null)
          throw System.Data.Linq.SqlClient.Error.ArgumentNull("provider");
        SqlProvider sqlProvider = provider as SqlProvider;
        if (sqlProvider == null)
          throw System.Data.Linq.SqlClient.Error.ArgumentTypeMismatch((object) "provider");
        if (!SqlProvider.CompiledQuery.AreEquivalentShapes(this.originalShape, sqlProvider.services.Context.LoadOptions))
          throw System.Data.Linq.SqlClient.Error.CompiledQueryAgainstMultipleShapesNotSupported();
        else
          return sqlProvider.ExecuteAll(this.query, this.queryInfos, this.factory, arguments, this.subQueries);
      }
