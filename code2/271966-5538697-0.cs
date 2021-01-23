    public class Record
    {
        public int ID { get; set; }
        public Record()
        {
            // ... do general initialisation here ...
        }
    }
    public class StudentRecord : Record
    {
        public string StudentID { get; set; }
        public StudentRecord()
            : base()    // This calls the inherited Record constructor,
                        // so it does all the general initialisation
        {
            // ... do initialisations specific to StudentRecord here ...
        }
    }
    public class client
    {
        public static void Main()
        {
            // This calls the constructor for StudentRecord, which
            // in turn calls the constructor for Record.
            StudentRecord st = new StudentRecord();
        }
    }
