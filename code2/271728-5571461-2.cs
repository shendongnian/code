    public class DomainObject : IDomainObject
    {
        private readonly IList<IList> m_Collections = new List<IList>();
    
        protected void RegisterCollection<T>(List<T> collection) where T : IDomainObject
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
                foreach (var item in itemCollection))
                {
                    ((IDomainObject)item).Save();
                }
            }
        }        
    }
    public interface IDomainObject
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        /// <value>
        /// The id.
        /// </value>
        int Id { get; set; }
        /// <summary>
        /// Saves this instance.
        /// </summary>
        void Save();
        /// <summary>
        /// Deletes this instance.
        /// </summary>
        void Delete();
    }
