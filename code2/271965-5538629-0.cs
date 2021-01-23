    public class Record
    {
        public Record() { ID = -1; }
        public int ID { get; set; }
    }
    public class StudentRecord : Record
    {
        public StudentRecord() { StudentID = ""; }
        public string StudentID { get; set; }
    }
    // etc.
