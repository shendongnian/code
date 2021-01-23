    public List<SessionObjectDataItem> DirtyItems
    {
        get
        {
            return this.AsQueryAble().Where<SessionObjectDataItem>(d => d.IsDirty).ToList();
        }
    }
