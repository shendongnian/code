    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using MoreLinq;
    using NHibernate;
    using NHibernate.SqlCommand;
    using NHibernate.Type;
    public class CompositeInterceptor : IInterceptor
    {
        private readonly IEnumerable<IInterceptor> _interceptors;
        public CompositeInterceptor(IEnumerable<IInterceptor> interceptors)
        {
            _interceptors = interceptors.ToList();
        }
        public void AfterTransactionBegin(ITransaction tx)
        {
            _interceptors.ForEach(x => x.AfterTransactionBegin(tx));
        }
        public void AfterTransactionCompletion(ITransaction tx)
        {
            _interceptors.ForEach(x => x.AfterTransactionCompletion(tx));
        }
        public void BeforeTransactionCompletion(ITransaction tx)
        {
            _interceptors.ForEach(x => x.BeforeTransactionCompletion(tx));
        }
        public int[] FindDirty(object entity, object id, object[] currentState, 
            object[] previousState, string[] propertyNames, IType[] types)
        {
            var results = _interceptors
                .Select(interceptor => interceptor.FindDirty(entity, id,
                    currentState, previousState, propertyNames, types))
                .Where(result => result != null)
                .SelectMany(x => x)
                .Distinct()
                .ToArray();
            return !results.Any() ? null : results;
        }
        public object GetEntity(string entityName, object id)
        {
            return _interceptors
                .Select(interceptor => interceptor.GetEntity(entityName, id))
                .FirstOrDefault(result => result != null);
        }
        public string GetEntityName(object entity)
        {
            return _interceptors
                .Select(interceptor => interceptor.GetEntityName(entity))
                .FirstOrDefault(result => result != null);
        }
        public object Instantiate(string entityName, EntityMode entityMode, object id)
        {
            return _interceptors
                .Select(interceptor => interceptor.Instantiate(entityName, entityMode, id))
                .FirstOrDefault(result => result != null);
        }
        public bool? IsTransient(object entity)
        {
            return _interceptors
                .Select(interceptor => interceptor.IsTransient(entity))
                .FirstOrDefault(result => result != null);
        }
        public void OnCollectionRecreate(object collection, object key)
        {
            _interceptors.ForEach(x => x.OnCollectionRecreate(collection, key));
        }
        public void OnCollectionRemove(object collection, object key)
        {
            _interceptors.ForEach(x => x.OnCollectionRemove(collection, key));
        }
        public void OnCollectionUpdate(object collection, object key)
        {
            _interceptors.ForEach(x => x.OnCollectionUpdate(collection, key));
        }
        public void OnDelete(object entity, object id, object[] state, 
            string[] propertyNames, IType[] types)
        {
            _interceptors.ForEach(x => x.OnDelete(entity, id, state, propertyNames, types));
        }
        public bool OnFlushDirty(object entity, object id, object[] currentState, 
            object[] previousState, string[] propertyNames, IType[] types)
        {
            return _interceptors.Count(interceptor => interceptor.OnFlushDirty(
                entity, id, currentState, previousState, propertyNames, types)) > 0;
        }
        public bool OnLoad(object entity, object id, object[] state, 
            string[] propertyNames, IType[] types)
        {
            return _interceptors.Count(interceptor => interceptor.OnLoad(
                entity, id, state, propertyNames, types)) > 0;
        }
        public SqlString OnPrepareStatement(SqlString sql)
        {
            return _interceptors.Aggregate(sql, (current, interceptor) => 
                interceptor.OnPrepareStatement(current));
        }
        public bool OnSave(object entity, object id, object[] state, 
            string[] propertyNames, IType[] types)
        {
            return _interceptors.Count(interceptor => interceptor.OnSave(
                entity, id, state, propertyNames, types)) > 0;
        }
        public void PostFlush(ICollection entities)
        {
            _interceptors.ForEach(x => x.PostFlush(entities));
        }
        public void PreFlush(ICollection entities)
        {
            _interceptors.ForEach(x => x.PreFlush(entities));
        }
        public void SetSession(ISession session)
        {
            _interceptors.ForEach(x => x.SetSession(session));
        }
    }
