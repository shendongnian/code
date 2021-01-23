    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace Wingspan.Web.Mvc
    {
        public interface IRepository<TEntity> where TEntity : class
        {
            List<TEntity> FetchAll();
            IQueryable<TEntity> Query {get;}
            void Add(TEntity entity);
            void Delete(TEntity entity);
            void Save();
        }
    }
