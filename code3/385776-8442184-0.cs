    private List<Item> Filter(List<Item> itemList)
            {
                
                List<Item> filteredItems = (from c in itemList
                                            where c.IsBindable == true
                                            select c).ToList();
                foreach (Item item in filteredItems)
                {
                    if (item.Item != null)
                        item.Item = Filter(item.Item);
                }
    
                return filteredItems;
            }
    class Item
        {
            public List<Item> Item { get; set; }
            public bool IsBindable { get; set; }
    
            public Item()
            {
                IsBindable = false;
            }
    
        }
