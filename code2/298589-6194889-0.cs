    int IList.Add(object value)
    {
        TEntity tEntity = value as TEntity;
        if (tEntity == null || this.IndexOf(tEntity) >= 0)
        {
            throw Error.ArgumentOutOfRange("value");
        }
        this.CheckModify();
        int count = this.entities.Count;
        this.entities.Add(tEntity);
        this.OnAdd(tEntity);
        return count;
    }
    
    // System.Data.Linq.EntitySet<TEntity>
    /// <summary>Adds an entity.</summary>
    /// <param name="entity">The entity to add.</param>
    public void Add(TEntity entity)
    {
        if (entity == null)
        {
            throw Error.ArgumentNull("entity");
        }
        if (entity != this.onAddEntity)
        {
            this.CheckModify();
            if (!this.entities.Contains(entity))
            {
                this.OnAdd(entity);
                if (this.HasSource)
                {
                    this.removedEntities.Remove(entity);
                }
                this.entities.Add(entity);
                this.OnListChanged(ListChangedType.ItemAdded, this.entities.IndexOf(entity));
            }
            this.OnModified();
        }
    }
