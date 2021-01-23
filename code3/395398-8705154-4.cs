    public class JournalViewModel
    {
        public IEnumerable<Journals> GetJournals()
         {
             using(var db = new ErikDataContext())
              {
                  return db.Journals.ToList();
    
              }
         }
    }
