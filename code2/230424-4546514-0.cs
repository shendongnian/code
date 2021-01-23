    using System;
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
            }
        }
    
        public class DataContext : IDataContext
        {
            ObjectContext _entities;
    
            public DataContext(ObjectContext objectContext)
            {
                this._entities = objectContext;
            }
    
            public IQueryable<T> Query<T>()
                where T : class
            {
                return this._entities.CreateObjectSet<T>();
            }
        }
    
        interface IDataContext
        {
            IQueryable<T> Query<T>() where T : class;
        }
    }
