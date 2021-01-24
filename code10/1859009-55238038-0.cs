    public IHttpActionResult GetItems(string name)
    {
        List<Item> allItems = GetAllItems();
    
        return Ok(allItems.Where(i => i.Name.ToLower().Contains(name.ToLower())));
    }
