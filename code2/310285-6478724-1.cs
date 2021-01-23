    namespace New_Repository_Design.Repositories
    {
        using System;
        using System.Collections.Generic;
        using System.Data;
        using System.Data.Entity.Design.PluralizationServices;
        using System.Data.Objects;
        using System.Data.SqlClient;
        using System.Globalization;
        using System.Linq;
        using System.Linq.Expressions;
        using Specifications;
    
        public sealed class DomainRepository : IRepository
        {
            private readonly PluralizationService _pluralizer = PluralizationService.CreateService(CultureInfo.GetCultureInfo("en"));
    
            private readonly string _connectionStringName;
            private ObjectContext _objectContext;
    
            /// <summary>
            /// Initializes a new instance of the <see cref="GenericRepository&lt;TEntity&gt;"/> class.
            /// </summary>
            public DomainRepository()
                : this(string.Empty)
            {
            }
    
            /// <summary>
            /// Initializes a new instance of the <see cref="GenericRepository&lt;TEntity&gt;"/> class.
            /// </summary>
            /// <param name="connectionStringName">Name of the connection string.</param>
            public DomainRepository(string connectionStringName)
            {
                this._connectionStringName = connectionStringName;
            }
    
            /// <summary>
            /// Initializes a new instance of the <see cref="GenericRepository"/> class.
            /// </summary>
            /// <param name="objectContext">The object context.</param>
            public DomainRepository(ObjectContext objectContext)
            {
                if (objectContext == null)
                    throw new ArgumentNullException("objectContext");
                this._objectContext = objectContext;
            }
    
            public TEntity GetByKey<TEntity>(object keyValue) where TEntity : class
            {
                EntityKey key = GetEntityKey<TEntity>(keyValue);
    
                object originalItem;
                if (ObjectContext.TryGetObjectByKey(key, out originalItem))
                {
                    return (TEntity)originalItem;
                }
                return default(TEntity);
            }
    
            public IQueryable<TEntity> GetQuery<TEntity>() where TEntity : class
            {
                var entityName = GetEntityName<TEntity>();
                var q = ObjectContext.CreateQuery<TEntity>(entityName);
                //return ObjectContext.CreateQuery<TEntity>(entityName);
                return q;
            }
    
            public IQueryable<TEntity> GetQuery<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class
            {
                return GetQuery<TEntity>().Where(predicate);
            }
    
            public IQueryable<TEntity> GetQuery<TEntity>(ISpecification<TEntity> specification) where TEntity : class
            {
                return specification.SatisfyingEntitiesFrom(GetQuery<TEntity>());
            }
    
            public IEnumerable<TEntity> Get<TEntity>(Expression<Func<TEntity, string>> orderBy, int pageIndex, int pageSize, SortOrder sortOrder = SortOrder.Ascending) where TEntity : class
            {
                if (sortOrder == SortOrder.Ascending)
                {
                    return GetQuery<TEntity>().OrderBy(orderBy).Skip(pageIndex).Take(pageSize).AsEnumerable();
                }
                return GetQuery<TEntity>().OrderByDescending(orderBy).Skip(pageIndex).Take(pageSize).AsEnumerable();
            }
    
            public IEnumerable<TEntity> Get<TEntity>(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, string>> orderBy, int pageIndex, int pageSize, SortOrder sortOrder = SortOrder.Ascending) where TEntity : class
            {
                if (sortOrder == SortOrder.Ascending)
                {
                    return GetQuery<TEntity>().Where(predicate).OrderBy(orderBy).Skip(pageIndex).Take(pageSize).AsEnumerable();
                }
                return GetQuery<TEntity>().Where(predicate).OrderByDescending(orderBy).Skip(pageIndex).Take(pageSize).AsEnumerable();
            }
    
            public IEnumerable<TEntity> Get<TEntity>(ISpecification<TEntity> specification, Expression<Func<TEntity, string>> orderBy, int pageIndex, int pageSize, SortOrder sortOrder = SortOrder.Ascending) where TEntity : class
            {
                if (sortOrder == SortOrder.Ascending)
                {
                    return specification.SatisfyingEntitiesFrom(GetQuery<TEntity>()).OrderBy(orderBy).Skip(pageIndex).Take(pageSize).AsEnumerable();
                }
                return specification.SatisfyingEntitiesFrom(GetQuery<TEntity>()).OrderByDescending(orderBy).Skip(pageIndex).Take(pageSize).AsEnumerable();
            }
    
            public TEntity Single<TEntity>(Expression<Func<TEntity, bool>> criteria) where TEntity : class
            {
                return GetQuery<TEntity>().SingleOrDefault<TEntity>(criteria);
            }
    
            public TEntity Single<TEntity>(ISpecification<TEntity> criteria) where TEntity : class
            {
                return criteria.SatisfyingEntityFrom(GetQuery<TEntity>());
            }
    
            public TEntity First<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class
            {
                return GetQuery<TEntity>().FirstOrDefault(predicate);
            }
    
            public TEntity First<TEntity>(ISpecification<TEntity> criteria) where TEntity : class
            {
                return criteria.SatisfyingEntitiesFrom(GetQuery<TEntity>()).FirstOrDefault();
            }
    
            public void Add<TEntity>(TEntity entity) where TEntity : class
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("entity");
                }
                ObjectContext.AddObject(GetEntityName<TEntity>(), entity);
            }
    
            public void Attach<TEntity>(TEntity entity) where TEntity : class
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("entity");
                }
    
                ObjectContext.AttachTo(GetEntityName<TEntity>(), entity);
            }
    
            public void SaveChanges()
            {
                this.ObjectContext.SaveChanges();
            }
    
            public void Delete<TEntity>(TEntity entity) where TEntity : class
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("entity");
                }
                ObjectContext.DeleteObject(entity);
            }
    
            public void Delete<TEntity>(Expression<Func<TEntity, bool>> criteria) where TEntity : class
            {
                IEnumerable<TEntity> records = Find<TEntity>(criteria);
    
                foreach (TEntity record in records)
                {
                    Delete<TEntity>(record);
                }
            }
    
            public void Delete<TEntity>(ISpecification<TEntity> criteria) where TEntity : class
            {
                IEnumerable<TEntity> records = Find<TEntity>(criteria);
                foreach (TEntity record in records)
                {
                    Delete<TEntity>(record);
                }
            }
    
            public IEnumerable<TEntity> GetAll<TEntity>() where TEntity : class
            {
                return GetQuery<TEntity>().AsEnumerable();
            }
    
            public void Update<TEntity>(TEntity entity) where TEntity : class
            {
                var fqen = GetEntityName<TEntity>();
    
                object originalItem;
                EntityKey key = ObjectContext.CreateEntityKey(fqen, entity);
                if (ObjectContext.TryGetObjectByKey(key, out originalItem))
                {
                    ObjectContext.ApplyCurrentValues(key.EntitySetName, entity);
                }
            }
    
            public IEnumerable<TEntity> Find<TEntity>(Expression<Func<TEntity, bool>> criteria) where TEntity : class
            {
                return GetQuery<TEntity>().Where(criteria);
            }
    
            public TEntity FindOne<TEntity>(Expression<Func<TEntity, bool>> criteria) where TEntity : class
            {
                return GetQuery<TEntity>().Where(criteria).FirstOrDefault();
            }
    
            public TEntity FindOne<TEntity>(ISpecification<TEntity> criteria) where TEntity : class
            {
                return criteria.SatisfyingEntityFrom(GetQuery<TEntity>());
            }
    
            public IEnumerable<TEntity> Find<TEntity>(ISpecification<TEntity> criteria) where TEntity : class
            {
                return criteria.SatisfyingEntitiesFrom(GetQuery<TEntity>());
            }
    
            public int Count<TEntity>() where TEntity : class
            {
                return GetQuery<TEntity>().Count();
            }
    
            public int Count<TEntity>(Expression<Func<TEntity, bool>> criteria) where TEntity : class
            {
                return GetQuery<TEntity>().Count(criteria);
            }
    
            public int Count<TEntity>(ISpecification<TEntity> criteria) where TEntity : class
            {
                return criteria.SatisfyingEntitiesFrom(GetQuery<TEntity>()).Count();
            }
    
            private ObjectContext ObjectContext
            {
                get
                {
                    return this._objectContext;
                }
            }
    
            private string GetEntityName<TEntity>() where TEntity : class
            {
                return string.Format("{0}.{1}", ObjectContext.DefaultContainerName, _pluralizer.Pluralize(typeof(TEntity).Name));
            }
    
            private EntityKey GetEntityKey<TEntity>(object keyValue) where TEntity : class
            {
                var entitySetName = GetEntityName<TEntity>();
                var objectSet = ObjectContext.CreateObjectSet<TEntity>();
                var keyPropertyName = objectSet.EntitySet.ElementType.KeyMembers[0].ToString();
                var entityKey = new EntityKey(entitySetName, new[] { new EntityKeyMember(keyPropertyName, keyValue) });
                return entityKey;
            }
        }
    }`
