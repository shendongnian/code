    [Route("/path/to/callback")]
    public class CorpNotes
    {
        public int Departments { get; set; }
    
        public string Note { get; set; }
    
        public DateTime WeekEnding { get; set; }
    }
    public class MyServices : Service
    {
        public object Any(CorpNotes request)
        {
            //...
        }
    }
