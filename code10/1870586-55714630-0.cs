    public async Task<IActionResult> Edit(NewViewModel value)
    {
        if (!ModelState.IsValid)
        {
            PopulateDropDowns();
            return View(value);            
        }
        var entity = await _newBL.GetById(id);
        if (entity == null)
            return NotFound();
        entity.Title = value.Title;
        entity.Message = value.Message;
        entity.TowerID = value.TowerID;
        entity.Resources = _files;
        await _newBL.Update(entity);
        return RedirectToAction(nameof(Index));
    }
