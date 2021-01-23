    using System;
    using System.Collections.Generic;
    using System.Data.Metadata.Edm;
    using System.Data.Objects;
    using System.Linq;
    
    namespace WindowsFormsApplication2
    {
        static class Program
        {
            [STAThread]
            static void Main()
            {
                var context = new DataContext(new NorthwindEntities());
                var list = context.Query<Customer>().ToList();
            }
        }
    
        public class DataContext : IDataContext
        {
            private Dictionary<string, string> _entitySets;
            private ObjectContext _entities;
    
            public DataContext(ObjectContext objectContext)
            {
                this._entities = objectContext;
            }
    
            public IQueryable<T> Query<T>()
                where T : class
            {
                return this._entities.CreateQuery<T>(this.GetEntitySetName<T>());
            }
    
            private string GetEntitySetName<T>()
                where T : class
            {
                if (this._entitySets == null)
                {
                    // create a dictionary of the Entity Type/EntitySet Name
                    this._entitySets = this._entities.MetadataWorkspace
                                                     .GetItems<EntityContainer>(DataSpace.CSpace)
                                                     .First()
                                                     .BaseEntitySets.OfType<EntitySet>().ToList()
                                                     .ToDictionary(d => d.ElementType.Name, d => d.Name);
                }
    
                Type entityType = typeof(T);
    
                // lookup the entity set name based on the entityType
                return this._entitySets[entityType.Name];
            }
        }
    
        interface IDataContext
        {
            IQueryable<T> Query<T>() where T : class;
        }
    }
