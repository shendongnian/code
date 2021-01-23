    protected virtual string ParameterPrefix
    {
      get
      {
        if (!string.IsNullOrEmpty(this._owner.ProviderName) && !string.Equals(this._owner.ProviderName, "System.Data.SqlClient", StringComparison.OrdinalIgnoreCase))
        {
          return string.Empty;
        }
        return "@";
      }
    }
