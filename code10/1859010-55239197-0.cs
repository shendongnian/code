     public IHttpActionResult GetItems(string name)
     {
         List<Item> allItems = GetAllItems();
  
         //We are ignoring the Case Sensitivity and comparing the items with name
         return Ok(allItems.Where(x => x.Name.Equals(name,StringComparison.CurrentCultureIgnoreCase));
    }
