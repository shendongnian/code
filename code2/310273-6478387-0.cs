    public virtual void RemoveNote(int id)
    {
       //remove the note from the list here
       Notes = Notes.Where(note => note.Id != id).ToList();
    }
