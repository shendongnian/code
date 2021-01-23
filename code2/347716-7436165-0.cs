    public class EmployeeRepository
    {
        public IList<Employee> GetAll() {}
    }
    
    public class MeetingRepository
    {
        public IList<Meeting> GetAll(){}
    
        public IList<Meeting> GetMeetingsAttendedByEmployee( Employee emp ){}
    }
