    public virtual IEnumerable<CreamModel> GetAll
    {
        get
        {
            return context.CreamModels.Include(a => a.CreamTypeModel);
        }
    }
