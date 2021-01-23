    public class Folder
    {
    }
    
    public class Item
    {
    }
    
    public IEnumerable<Object> GetChildren()
    {
    
        Folder[] Folders = new Folder[] { };
        Item[] Items = new Item[] { };
    
        return ((IEnumerable<Object>)(from Folder folder in Folders 
                                      select folder))
                                      .Union<Object>(
               (IEnumerable<Object>)(from Item item in Items select item));
    }
