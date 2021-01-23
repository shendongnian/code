    public virtual DbEntityValidationResult GetValidationResult(IDictionary<object, object> items)
    {
        EntityValidator entityValidator = 
            this.InternalContext.ValidationProvider.GetEntityValidator(this);
        bool lazyLoadingEnabled = this.InternalContext.LazyLoadingEnabled;
        this.InternalContext.LazyLoadingEnabled = false;
        DbEntityValidationResult result = null;
        try
        {
            ...
        }
        finally
        {
            this.InternalContext.LazyLoadingEnabled = lazyLoadingEnabled;
        }
        return result;
    }
