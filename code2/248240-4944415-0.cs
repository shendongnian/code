    public override string Message
    {
        get
        {
           return string.Format("Can't find a record for {0}.", _entityName)
            + _details != null ? string.Format(" Details: {0}", _details): String.Empty;
        }
    }
