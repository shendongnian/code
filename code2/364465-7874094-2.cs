    public class Storage 
    {       
       public void Store<TItem>(TItem item)  
          where TItem: IItem
       {          
           IList<TItem> items = new List<TItem>();
       }
    }
