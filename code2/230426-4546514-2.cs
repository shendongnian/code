    using System;
    using System.Collections.Generic;
    using System.Data.Objects;
    using System.Linq;
    
    namespace WindowsFormsApplication1
    {
        static class Program
        {
            [STAThread]
            static void Main()
            {
                var context = new DataContext(new NorthwindEntities());
                var list = context.Query<Customer>().ToList();
                var list2 = context.Query<Customer>().ToList();
            }
        }
    
        public class DataContext : IDataContext
        {
            private Dictionary<Type, object> _objectSets = new Dictionary<Type,object>();
            private ObjectContext _entities;
    
            public DataContext(ObjectContext objectContext)
            {
                this._entities = objectContext;
            }
    
            public IQueryable<T> Query<T>()
                where T : class
            {
                Type entityType = typeof(T);
                ObjectSet<T> objectSet;
    
                if (this._objectSets.ContainsKey(entityType))
                {
                    objectSet = this._objectSets[entityType] as ObjectSet<T>;
                }
                else
                {
                    objectSet = this._entities.CreateObjectSet<T>();
                    this._objectSets.Add(entityType, objectSet);
                }
    
                return objectSet;
            }
        }
    
        interface IDataContext
        {
            IQueryable<T> Query<T>() where T : class;
        }
    }
