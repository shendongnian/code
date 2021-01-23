    public class TitleRepository : CrudRepository<Title>
    {
    	public TitleRepository()
    		: base(new DbEntities())
    	{
    	}
    }
    
    public abstract class CrudRepository<TEntity> :
    	ICanCreate<TEntity>,
    	ICanUpdate<TEntity>,
    	ICanDelete<TEntity>,
    	ICanGetList<TEntity>,
    	ICanGetById<TEntity>
    	where TEntity : EntityObject
    {
    	private readonly ObjectSet<TEntity> _objectSet;
    	private readonly string _primaryKey;
    	
    	protected CrudRepository(ObjectContext context)
    	{
    		this._objectSet = context.CreateObjectSet<TEntity>();
    		this._primaryKey = this.GetPrimaryKeyPropertyName();
    	}
    
    	public void Create(TEntity entity)
    	{
    		this._objectSet.AddObject(entity);
    		this._objectSet.Context.SaveChanges();
    	}
    
    	public bool Update(TEntity entity)
    	{
    		if (entity.EntityState == EntityState.Detached)
    		{
    			this._objectSet.Attach(entity);
    		}
    
    		this._objectSet.Context.SaveChanges();
    		return true;
    	}
    
    	public bool Delete(TEntity entity)
    	{
    		this._objectSet.DeleteObject(entity);
    		this._objectSet.Context.SaveChanges();
    		return true;
    	}
    
    	public IEnumerable<TEntity> GetList()
    	{
    		return this._objectSet.ToList();
    	}
    
    	public TEntity GetById(int id)
    	{
    		return this._objectSet.Where(this.CreateGetByIdExpression(id)).FirstOrDefault();
    	}
    
    	// Build an Expression that can be used to query an Entity by Id.
    	private Expression<Func<TEntity, bool>> CreateGetByIdExpression(object id)
    	{
    		ParameterExpression e = Expression.Parameter(typeof(TEntity), "e");
    		PropertyInfo pi = typeof(TEntity).GetProperty(this._primaryKey);
    		MemberExpression m = Expression.MakeMemberAccess(e, pi);
    		ConstantExpression c = Expression.Constant(id, id.GetType());
    		BinaryExpression b = Expression.Equal(m, c);
    		Expression<Func<TEntity, bool>> lambda = Expression.Lambda<Func<TEntity, bool>>(b, e);
    
    		return lambda;
    	}
    
    	// Use the EF metadata to get the primary key property name.
    	private string GetPrimaryKeyPropertyName()
    	{
    		return this._objectSet.Context
    							  .MetadataWorkspace
    							  .GetEntityContainer(this._objectSet.Context.DefaultContainerName, DataSpace.CSpace)
    							  .BaseEntitySets
    							  .First(meta => meta.ElementType == this._objectSet.EntitySet.ElementType)
    							  .ElementType.KeyMembers
    							  .Select(k => k.Name)
    							  .FirstOrDefault();
    	}
    }
