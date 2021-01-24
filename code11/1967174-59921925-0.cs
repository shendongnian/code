    ...
    
    public class InnerItemType
    {
        public int sortOrder { get; set;  }
        public string value { get; set; }
    }
    
    ....
    
    List<InnerItemType> listOptions = new List<InnerItemType>();
    var configItemsElement = Config["items"] as IEnumerable;
    foreach (var item in configItemsElement)
    {
        dynamic innerItem = item.GetType().GetProperties()[1].GetValue(item);
        listOptions.Add(new InnerItemType() { 
            value = innerItem.GetType().GetProperties()[0].GetValue(innerItem), 
            sortOrder = innerItem.GetType().GetProperties()[1].GetValue(innerItem)
        });
    }
    ...
