public class GenericRepository<TEntity> where TEntity : class
{
    internal PayloadContext context;
    internal DbSet<TEntity> dbSet;
    public GenericRepository( PayloadContext context )
    {
        this.context = context;
        this.dbSet = context.Set<TEntity>();
    }
    ....
}
And I hadn't really looked closely enough at that second line in the constructor.
I'd seen that the context was now created in th UnitOfWork, and passed into the various repositories so that all the repositories could share it.
But I'd thought, incorrectly, that what was happening above was the a DbSet was being created for this repository. Therefore I removed the declaration of the DbSet  properties from my context, thinking I'd never use them, and that I'd now be accessing the data through the repositories.
In other words in the controllers, for example, I thought I was never doing:
MyContext db = new MyContext();
and
public ActionResult Index()
{
    return View( db.MySetPropertyDeclaredInMyContext.Get() )
}
but rather
private UnitOfWork unitOfWork = new UnitOfWork();
and
public ActionResult Index()
{
    return View( unitOfWork .MySetPropertyDeclaredInMyUoW.Get() )
}
By the time I got back to "fixing up" the initialisation code I was was stuck because that had the context passed in and the "old" entity sets directly referenced. Further I don't call the Seed method myself from my own code.
What I realised is that the second line in the constructor of the GenericRepository was only setting a reference to a DBSet (that's a method, not a 'new'). What's more *"Entity Framework requires that this method return the same instance each time that it is called for a given context instance and entity type."*
With that in mind, I still needed my original DbSet property declarations inside the context.
The DatabaseInitializer Seed method could remain unchanged.
For completeness, for those wondering where this is called:
*An implementation of this interface [IDatabaseInitializer] is used to initialize the underlying database when an instance of a DbContext derived class is used for the first time. This initialization can conditionally create the database and/or seed it with data. The strategy used is set using the static InitializationStrategy property of the Database class*
So in other words, this initialisation code was fine and would be triggered first time the context was used which would be first time a UnitOfWork was performed. (Or maybe even invoked).
