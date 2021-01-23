    public void AddParameter(string paramName, object objValue)
    {
      IDataParameter newParam = DBManagerFactory.GetParameter(this.ProviderType);
      newParam.ParameterName = paramName;
      newParam.Value = objValue;
      if (idbParametersList == null)
        idbParametersList = new List<IDbDataParameter>();
      idbParametersList.Add((IDbDataParameter)newParam);
      if (dbParameterCollection == null)
        dbParameterCollection = (DbParameterCollection)DBManagerFactory.GetCommand(this.ProviderType).Parameters;
      dbParameterCollection.Add(newParam);
    }
