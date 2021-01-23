    public class Employee
    {
        public int emp_Id { get; set; }
        public string lastName { get; set; }
        public string firstName { get; set; }
        public string fullName
        {
            get
            { 
                return String.Format("{0} {1}", this.firstName, this.LastName);
            }
        }
    
        public Employee(int id, string last, string first)
        {
            this.emp_Id = id;
            this.lastName = last;
            this.firstName = first;
        }
    }
