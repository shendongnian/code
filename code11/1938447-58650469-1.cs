    [Route("/path/to/callback")]
    public class CorpNotes
    {
        public int Departments { get; set; }
    
        public string Note { get; set; }
    
        public DateTime WeekEnding { get; set; }
    }
    // Example of OrmLite POCO Data Model 
    public class MyTable {} 
    public class MyServices : Service
    {
        public object Any(CorpNotes request)
        {
            //... 
            Db.Insert(request.ConvertTo<MyTable>());
        }
    }
