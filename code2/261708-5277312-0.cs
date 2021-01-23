    public void DeleteAllOnSubmit<TSubEntity>(IEnumerable<TSubEntity> entities) where TSubEntity: TEntity
    {
        if (entities == null)
        {
            throw Error.ArgumentNull("entities");
        }
        this.CheckReadOnly();
        this.context.CheckNotInSubmitChanges();
        this.context.VerifyTrackingEnabled();
        foreach (TEntity local in entities.ToList<TSubEntity>())
        {
            this.DeleteOnSubmit(local);
        }
    }
