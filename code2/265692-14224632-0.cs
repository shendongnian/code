         IQueryable<File> xg= UnitOfWork.Files.GetAllLazyLoad(d => d.FileId == 1, 
                r => r.FileCategory);
    //where r.FileCategory is a navigational property.
    
    //Interface
        
        namespace Msh.Intranet.Repository.GenericRepoPattern
        {
            public interface IRepository<T> where T:class
            {
    
                IQueryable<T> GetAllLazyLoad(Expression<Func<T, bool>> filter, params Expression<Func<T, object>>[] children);
    
            }
        }
        
        
            namespace Msh.Intranet.Repository.GenericRepoPattern
            {
                /// <summary>
                /// The EF-dependent, generic repository for data access
                /// </summary>
                /// <typeparam name="T">Type of entity for this Repository.</typeparam>
                public class EFRepository<T> : IRepository<T> where T : class
                {
                    public EFRepository(DbContext dbContext)
                    {
                        if (dbContext == null)
                            throw new ArgumentNullException("dbContext");
                        DbContext = dbContext;
                        DbSet = DbContext.Set<T>();
                     
                    }
            
                    protected DbContext DbContext { get; set; }
            
                    protected DbSet<T> DbSet { get; set; }
            
    
                    public virtual IQueryable<T> GetAllLazyLoad(Expression<Func<T, bool>> filter, params Expression<Func<T, object>>[] children) 
                    {
            
                        
                            children.ToList().ForEach(x=>DbSet.Include(x).Load());
                            return DbSet;
                    }
            
                }
            }
