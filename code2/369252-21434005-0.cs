    public class Entitlement : IEntity
    {
        #region Implementation of IEntity
        public string Id { get; set; }
        #endregion
    
        public string ItemId { get; set; }
    
        public virtual Item Item { get; set; }
    }
