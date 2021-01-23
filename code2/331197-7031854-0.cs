    interface IEmployeeManager {
        void AddEmployee(ProspectiveEmployee e);
        void RemoveEmployee(Employee e);
    }
    
    class HiringOfficer {
        private readonly IEmployeeManager manager
        public HiringOfficer(IEmployeeManager manager) {
            this.manager = manager;
        }
        public void HireProspect(ProspectiveEmployee e) {
            manager.AddEmployee(e);
        }
    }
