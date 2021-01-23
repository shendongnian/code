    public class ControlArgs
    {
        //MDI form source
        public InteruptSource source { get; set; }
        //Interrupt type
        public EVInterupts clockInt { get; set; }
        //in this case only a date is needed
        //but normally I include optional data (as if a C UNION type)
        //the form that responds to the event decides if
        //the data is for it.
        public DateTime date { get; set; }
        //CI_STOCKIN
        public StockClass inStock { get; set; }
    }
    
