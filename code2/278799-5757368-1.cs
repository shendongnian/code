    public partial class Table1
    {
        /// <summary> 
        /// Gets the object context for this entity. Returns <c>null</c> if the entity is detached.
        /// </summary> 
        public Database1Entities ObjectContext { get { return Database1Entities.FromEntity(this); } }
    }
