    public interface IGenericManager { }
    public class GenericManager<T> : IGenericManager where T : Updateable { }
    public class EntityManager : GenericManager<Entity> { }
    var list = new List<IGenericManager>();
    var entityManagers = list.OfType<EntityManager>();
