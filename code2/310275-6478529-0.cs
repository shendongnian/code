    public class DomainClass
    {
      public virtual string name{get;set;}
      public virtual IDictionary<int, Note> Notes {get; set;}
    
      //Helper property to get the notes in the dictionary
      public IEnumerable<Note> AllNotes
      {
        get
        {
          return notes.Select (n => n.Value);
        }
      }
    
      public virtual void RemoveNote(int id)
      {
         Notes.Remove(id);
      }
