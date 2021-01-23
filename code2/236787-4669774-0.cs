    public interface IClinicRepository : IRepository<Clinic> {}
    public class ObjectFactory
    {
       public static IRepository<T> GetRepository(RepositoryType type)
       { 
         switch (type)
         {
             case RepositoryType.ClinicRepository:
                 return container.Resolve<IClinicRepository>()
              default:
                 throw new NotSupportedException()
         } 
       }
    }
