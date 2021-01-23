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
                foreach (var item in (IEnumerable)itemCollection))
                {
                    ((IDomainObject)item).Save();
                }
            }
        }        
    }
