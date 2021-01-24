    public interface IMapper<TModel, TEntity>
    {
        TEntity MapModelToEntity(TModel source);
        TModel MapEntityToModel();
    }
