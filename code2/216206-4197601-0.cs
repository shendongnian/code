    [HttpPost]
    public ActionResult EntryEdit(StreamEntry model)
    {
        if (!ModelState.IsValid)
        {
            // the model was not valid => redisplay the form so that 
            // the user can fix errors
            return View(model);
        }
        // Remark: might need to load the model's corresponding stream
        // from the repository if its values weren't posted
        // the model was valid => update it in the database
        genesisRepository.Update(model);
        return RedirectToAction("EntryList", new { id = model.StreamID });
    }
