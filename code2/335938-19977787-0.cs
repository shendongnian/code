     public ActionResult Edit(int id)
        {
           
            ItemsStore item = itemStoreRepository.FindById(id);
            ViewBag.CategoryId = new SelectList(categoryRepository.Query().Get(), "Id", "Name",item.CategoryId);
           // ViewBag to pass values to View and SelectList(get list of items,valuefield,textfield,selectedValue)
            return View(item);
        }
