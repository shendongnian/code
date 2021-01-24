    public void SecretMethod()
    {
        var database = new MyMySQLDatabase(new CSharpMySQLDriver());
    
        // you will use the database here, which has the DoQuery,
        // BeginTransaction, RollbackTransaction and CommitTransaction methods
    }
