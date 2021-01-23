    public void Save(Context context)
    {
        using (Transaction scope = new TransactionScope)
        {
        context.SaveChanges(SaveOptions.DetectChangesBeforeSave);
        auditContext = new MyAuditContext();
        var auditLog=CreateAuditLog(Entry);
        myAudtContext.SaveChanges(SaveOptions.DetectChangesBeforeSave);
        scope.Complete();
        context.AcceptChanges();
        myAuditContext.AcceptChanges()
    }
}
