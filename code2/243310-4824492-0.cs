        try
        {
            repository.Add(entity);
        }
        catch(MyRepositoryException ex)
        {
            ViewData.ModelState.AddModelError(ex.Key, ex.Value.ToString(), ex.Message)
        }
        
        if (!ModelState.IsValid)
                    return Json(Failure(createView, model.SelectLists(repository)));
    
