    interface IMySuperRepositry : IRepository<MySuperEntity>
    {
       MySuperEntity GetBySuperProperty(SuperProperty superProperty);
    }
    public class MySuperEntityRepository : Repository, IMySuperRepository
    {...}
