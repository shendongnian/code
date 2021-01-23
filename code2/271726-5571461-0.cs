    public class DomainObject : IDomainObject
    {
        private readonly IList<object> m_Collections = new List<object>();
    
        protected void RegisterCollection<T>(Collection<T> collection) where T : IDomainObject
        {
            m_Collections.Add(collection);
        }
    
        public int Id { get; set; }
    
        /// <summary>
        /// Saves this instance collections.
        /// </summary>
        public virtual void Save()
        {
            SaveCollections();
        }
    
        private void SaveCollections()
        {
            foreach (var itemCollection in m_Collections)
            {
                foreach (var item in CreateGeneric(typeof(Collection<>), GetBaseType(itemCollection), itemCollection))
                {
                    ((IDomainObject)item).Save();
                }
            }
        }
    
        private static Type GetBaseType(object genericCollection)
        {
            var collectionType = genericCollection.GetType();
    
            if (collectionType.BaseType == null)
                throw new InvalidOperationException("BaseType is null.");
    
            Type[] listTypes = collectionType.BaseType.GetGenericArguments();
    
            if (listTypes.Length != 1)
                throw new InvalidOperationException("BaseType did not return one specific type");
            return listTypes[0];
        }
    
        private static IEnumerable CreateGeneric(Type generic, Type innerType, object collection, params object[] args)
        {
            var specificType = generic.MakeGenericType(new[] { innerType });
            var typedCollection = Activator.CreateInstance(specificType, args);
            typedCollection = collection;
            return (IEnumerable)typedCollection;
        }
    }
