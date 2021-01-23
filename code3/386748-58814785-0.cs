    public class tblReservation
    {
        public tblReservation(int id, DateTime startTime, DateTime endTime, int schoolID, int accomodationID)
        {
        ID = id;
        StartTime = startTime;
        EndTime = endTime;
        SchoolID = schoolID;
        AccomodationID = accomodationID;
        }
        public int ID { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int SchoolID { get; set; }
        public int AccomodationID { get; set; }
    }
    public class tblMeeting
    {
        public tblMeeting(int id, DateTime startTime, DateTime endTime, string subject, string location)
        {
        ID = id;
        StartTime = startTime;
        EndTime = endTime;
        Subject = subject;
        Location = location;
        }
        public int ID { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Subject { get; set; }
        public string Location { get; set; }
    }
