    // Item types
    enum StorageItemType
    {
      A,
      B
    }
    
    interface IItem
    {
       int UID { get; }
       StorageItemType ItemType { get; }
    }
       
    public abstract class StorageItemBase: IItem
    {
      public int UID { get; private set; }
    
      public abstract StorageItemType ItemType 
    }
    
    public sealed class B : StorageItemBase    
    {
      public override StorageItemType ItemType 
      { 
        get 
        {
           return StorageItemType.B; // !!!
        }
      }
    }
