    public class LeaveRequestModel
    {
        public int LeaveId { get; set; }
        public string LeaveCode { get; set; }
        public string Reason { get; set; }
        public LeaveStatus Status { get; set; }
        public SelectList FilteredLeaveStatus {get;set;}
    }
