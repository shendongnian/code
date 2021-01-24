    public async Task<IActionResult> ProductAdd(ItemModel ItemModel)
        {
            if (ItemModel.BasicItem != null)
            {
               
                if (ItemModel.LocalItem != null)
                {
                    
                    await db.LocalItems.AddAsync(ItemModel.LocalItem);
                    await db.FoodItems.AddAsync(ItemModel.FoodItem);
                }
                //same for FoodItem
                ItemModel.BasicItem.LocalItem = ItemModel.LocalItem;
                ItemModel.BasicItem.FoodItem = ItemModel.FoodItem;
                await db.BasicItems.AddAsync(ItemModel.BasicItem);
                await db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ItemModel);
        }
