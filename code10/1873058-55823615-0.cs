    [HttpPost, ValidateInput(false)]
        public ActionResult CompletedNotes( int Id, string polNotes)
        {
    using (Db db = new Db())
            {
    CompletedPolicyVM completedPolicy=db.CompletedPolicyVM .Find(id);
        NotesDTO notesDTO = db.notes.Find(id);
    .
    .
    .
    
     db.SaveChanges();
    }
