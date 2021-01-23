    public void SaveChanges()
        {
            var newNotes = currentCalc.Notes.Where(n => n.NoteId == 0);
            DC.Notes.InsertAllOnSubmit(newNotes);
            DC.SubmitChanges();
        }
    }
