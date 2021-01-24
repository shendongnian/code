    public JsonResult GetNotesAsyncJson(string data)
    {
      var notes = this.noteService.SearchByTextAsync(data);
      var model = new SearchViewModel();
      model.Notes = notes;
    
      return Json(model.Notes);
    }
