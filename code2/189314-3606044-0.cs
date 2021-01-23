    public class Crud<EntityType> where EntityType : class
    {
        private readonly ObjectContext Context;
        private readonly IObjectSet<EntityType> Entities;
        public Crud(ObjectContext context)
        {
            Context = context;
            Type BaseType = GetBaseEntityType();
            if (BaseType == typeof(EntityType))
            {
                Entities = Context.CreateObjectSet<EntityType>();
            }
            else
            {
                Entities = (IObjectSet<EntityType>)Activator.CreateInstance(typeof(ObjectSetProxy<,>).MakeGenericType(typeof(EntityType), BaseType), Context);
            }
        }
        private static Type GetBaseEntityType()
        {
            //naive implementation that assumes the first class in the hierarchy derived from object is the "base" type used by EF
            Type t = typeof(EntityType);
            while (t.BaseType != typeof(Object))
            {
                t = t.BaseType;
            }
            return t;
        }
    }
    internal class ObjectSetProxy<EntityType, BaseEntityType> : IObjectSet<EntityType>
        where EntityType : BaseEntityType
        where BaseEntityType : class
    {
        private readonly IObjectSet<BaseEntityType> Entities;
        public ObjectSetProxy(ObjectContext context)
        {
            Entities = context.CreateObjectSet<BaseEntityType>();
        }
        public void AddObject(EntityType entity)
        {
            Entities.AddObject(entity);
        }
        //TODO: implement remaining proxy methods
        public IEnumerator<EntityType> GetEnumerator()
        {
            return Entities.OfType<EntityType>().GetEnumerator();
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public Type ElementType
        {
            get { return typeof(EntityType); }
        }
        public Expression Expression
        {
            get { return Entities.OfType<EntityType>().Expression; }
        }
        public IQueryProvider Provider
        {
            get { return Entities.Provider; }
        }
    }
