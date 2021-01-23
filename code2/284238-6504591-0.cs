    [HttpPost]
    public ActionResult Edit(FoodItem foodItem, ICollection<int> CategoryId)
    {
        if (ModelState.IsValid)
        {
            int id = foodItem.Id;
            // Load food item with related categories first
            var item = context.FoodItems
                              .Include(f => f.Categories)
                              .Single(f => f.Id == id);
    
            // Process changed scalar values
            context.Entry(item).CurrentValues.SetValues(foodItem);
    
            // Brute force processing of relations
            // This can be optimized - instead of deleting all and adding all again
            // you can manually compare which relations already exists, add new and
            // remove non existing but let's make that as a homework
            item.Categories.Clear();
    
            foreach (var id in CategoryID) 
            {
                // Use find - if category was already loaded in the first query, it will
                // be reused without additional query to DB
                var category = context.Categories.Find(id);
                // Now add category to attached food item to create new relation
                item.Categories.Add(category);
            }
    
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    
        return View(foodItem);
    }
