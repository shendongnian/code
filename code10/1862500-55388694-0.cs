    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthdate { get; set; }
        public Gender Gender { get; set; }
        public AppUser User { get; set; }
        public ICollection<EmployeeStatus> EmployeesStatus { get; set; }
        public ICollection<Resignation> Resignations { get; set; }
        public ICollection<RequestTracking> RequestTrackingsFrom { get; set; }
        public ICollection<RequestTracking> RequestTrackingsTo { get; set; }
    }
