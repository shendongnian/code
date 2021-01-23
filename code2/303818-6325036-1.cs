        [HttpPost]
        public ActionResult AddNote(AddNoteViewModel model)
        {
            var member = //Get member from db
            member.Notes.Add(new Note{Text = model.Text, Created = DateTime.Now});
            //SaveChanges();
    
            var notes = //Get notes for member
            
            return View(notes);
        }
