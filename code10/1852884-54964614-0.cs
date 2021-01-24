class Employee
    {
        private int employeeId;
        private string fullName;
        private float salary;
        private bool taxDeducted;
        public Employee(int employeeId, string fullName, float salary, bool taxDeducted=true)
        {
            this.employeeId = employeeId;
            this.fullName = fullName;
            this.salary = salary;
            this.taxDeducted = taxDeducted;
        }
       
        public float getNetSalary()
        {
            float tax = 0.8F;
            float salary = this.salary;
            if (taxDeducted)
                salary *= tax;
            return salary;
        }
        public void printInformation()
        {
            Console.WriteLine(employeeId + " " + fullName + " earns " + getNetSalary() + " per month");
        }
    }
then try it 
Employee john = new Employee(1, "John Doe", 20000, false);
john.printInformation();
// use Employee with tax
Employee jane = new Employee(2, "Jane Doe", 36000);
jane.printInformation();
1 John Doe earns 20000 per month
2 Jane Doe earns 28800 per month
