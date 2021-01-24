    class PayrollRunner
    {
        static void Main(string[] args)
        {
            // use Employee without tax
            Employee john = new Employee(1, "John Doe", 20000, false);
            Console.WriteLine(john.ToString());
            // use Employee with tax
            Employee jane = new Employee(2, "Jane Doe", 36000);
            Console.WriteLine(jane.ToString());
            // use WeeklyEmployee without tax
            // WeeklyEmployee jack = new WeeklyEmployee(3, "Jack Deer", 18500, false);
            //jack.printInformation();
            // use WeeklyEmployee with tax
            //WeeklyEmployee jen = new WeeklyEmployee(4, "Jen Deer", 18000);
            // jen.printInformation();
            Console.Read();
        }
    }
    class Employee
    {
        public int EmployeeId { get; set; }
        public string FullName { get; set; }
        public decimal Salary { get; set; }
        public bool TaxDeducted { get; set; }
        public decimal NetSalary { get; set; }
        public Employee(int employeeId, string fullName, decimal salary, bool taxDeducted)
        {
            EmployeeId = employeeId;
            FullName = fullName;
            Salary = salary;
            TaxDeducted = taxDeducted;
            NetSalary = GetNetSalary(salary, taxDeducted);
        }
        public Employee(int employeeId, string fullName, decimal salary)
        {
            EmployeeId = employeeId;
            FullName = fullName;
            Salary = salary;
            TaxDeducted = true;
            NetSalary = GetNetSalary(salary, true);
        }
        private decimal GetNetSalary(decimal grossPay, Boolean taxable)
        {
            decimal netPay;
            decimal tax = 0.8M;
            if (TaxDeducted)
                netPay = grossPay * tax;
            else
                netPay = grossPay;
            return netPay;
        }
        public override string ToString()
        {
            return $"{EmployeeId} {FullName} earns {NetSalary} per month";
        }
    }
}
