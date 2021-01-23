    public class Employee {
        public void ClockIn() {
            ....
        }
    }
    public class Manager: Employee {
        public void ClockIn() {
            // first, do what all Employees do when clocking in
            Employee.ClockIn();
            // Next, do Manager specific actions
            OpenSafe();
        }
        public void OpenSafe() {
            ....
        }
    }
