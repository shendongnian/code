        public interface IDao<T, TId> where T : IEntityWithTypedId<TId>
        { }
    
        public class Dao<T, TId> : IDao<T, TId> where T : EntityWithTypedId<TId> 
        { }
    
        public class TId
        { }
    
        public abstract class EntityWithTypedId<TId> : IEntityWithTypedId<TId>
        { }
    
        public interface IEntityWithTypedId<TId>
        { }
    
        IUnityContainer.RegisterType<IEntityWithTypedId<TId>, EntityWithTypedId<TId>>();
        IUnityContainer.RegisterType<IDao<IEntityWithTypedId<TId>, TId>, Dao<IEntityWithTypedId<TId>, TId>>();
        IDao<IEntityWithTypedId<TId>, TId> dao = IUnityContainer.Resolve<IDao<IEntityWithTypedId<TId>, TId>>();
