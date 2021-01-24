    public class BaseRepository<TEntity, TDTO> : IRepository<TEntity, TDTO>
        where TEntity : class, new()
    {
         protected DbContext _context;
         protected IAdaptable<TEntity, TDTO> _adapter;
         public BaseRepository(DbContext context, IAdaptable<TEntity, TDTO> adapter)
         {
             this._context = context;
             this._adapter = adapter;
         }
         public TDTO Add(TDTO dto)
         {
            var entity = this._adapter.ToEntity(dto, new TEntity());
            this._context.Set<TEntity>().Add(entity);
            this._context.SaveChanges();
            
             return this._adapter.ToDTO(entity);
         }
    }
