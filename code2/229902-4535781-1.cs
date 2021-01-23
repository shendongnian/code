    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data.Linq;
    
    using Wingspan.Web.Mvc;
    
    namespace ES.eLearning.Domain
    {
        public class SqlRepository<T> : IRepository<T> where T : class
        {
            DataContext db;
            public SqlRepository(DataContext db)
            {
                this.db = db;
            }
        
            #region IRepository<T> Members
    
            public IQueryable<T> Query
            {
                get { return db.GetTable<T>(); }
            }
    
            public List<T> FetchAll()
            {
                return Query.ToList();
            }
    
            public void Add(T entity)
            {
                db.GetTable<T>().InsertOnSubmit(entity);
            }
    
            public void Delete(T entity)
            {
                db.GetTable<T>().DeleteOnSubmit(entity);
            }
    
            public void Save()
            {
                db.SubmitChanges();
            }
    
            #endregion
        }
    }
