    public class OperationalDataItem
    {
       public int Id { get; set; }
       public String Comunity { get; set; }
       ...
       // Every OperationalDataItem has zero or more AssetItems (one-to-many)
       public virtual ICollection<AssetItem> AssetItems { get; set; }
    }
    public class AssetItem
    {
        public int Id { get; set; }
        public String Name { get; set; }
        ...
        // every AssetItem belongs to exactly one OperationalDataItem, using foreign key
        public int OperationDataItemId { get; set; }
        public virtual OperationalDataItem OperationalDataItem { get; set; }
    }
