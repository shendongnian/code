    public void AddEntities(List<YourEntity> entities)
    {
        using (var transactionScope = new TransactionScope())
        {
            DbContext context = new YourContext();
            int count = 0;
            foreach (var entity in entities)
            {
                ++count;
                context = context.AddToContext<TenancyNote>(entity, count, 100, true,
                    () => new YourContext());
            }
            context.SaveChanges();
            transactionScope.Complete();
        }
    }
