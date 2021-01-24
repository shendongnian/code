    public void executeBatchJob(int batchId)
    {
        using (vMyEntity myEntity = new MyEntity();) 
        {
           APrivateMethodInExecuteBatchJob(myEntity);
           // more code
        }
    }
