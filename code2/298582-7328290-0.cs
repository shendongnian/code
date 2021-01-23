    <!-- language: lang-c# -->
    public interface IRepository
    {
      SaveChanges()
    ...
    }
    public interface IRepositoryFor<T> where T : IPersistantBusinessObject
    {
      T GetFirst(); // or whatever
    ...
    }
