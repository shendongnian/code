    public void EndTransaction()
    {
        try
        {
            SessionManager.Instance.CommitTransactionOn(SessionFactoryConfigPath);
        }
        finally
        {
            SessionManager.Instance.CloseSessionOn(SessionFactoryConfigPath);
        }
    }
