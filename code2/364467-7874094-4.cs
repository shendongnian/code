    public class Storage 
    {       
       public Storage()
       {
         // create it once on construction stage
         // so you do not need to check for null each time in Sore()/Read()
         this.AllItems = new List<IItem>();
       }
       public IList<IItem> AllItems { get; private set; }
       public void Store<TItem>(TItem item)  
          where TItem: IItem
       {          
           this.AllItems.Add(item);
       }
       public IEnumerable<IItem> Read(StorageItemType itemType)
       {
          return this.AllItems.Where(item => item.ItemType == itemType);
       }
    }
