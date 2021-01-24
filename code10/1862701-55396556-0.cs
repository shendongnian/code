    [HttpPost]
     public ActionResult<Note>Create(Note note)
     {
        _noteService.Create(note);
        return CreatedAtRoute("GetNote", new { id = note.Id.ToString() }, note);
     }
