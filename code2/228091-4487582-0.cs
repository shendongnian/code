     public class ListCollection : List<string>
        {
            string _lastitem;
    
            public void Add(string item)
            {
                //TODO: Do  special treatment on the new Item, new item should be last one.
                //Not applicable for filter/sort
                 base.Add(item);
            }
        }
