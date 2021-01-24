    // only need TEntity for this generic method because we know we are an Address
    public Address MapToModel<TEntity>(IMapper<Address, TEntity> mapper)
    {
        return mapper.MapEntityToModel();
    }
    // only need TEntity for this generic method because we know we are an Address
    public TEntity MapToEntity<TEnity>(IMapper<Address, TEntity> mapper)
    {
        return mapper.MapModelToEntity(this);
    }
