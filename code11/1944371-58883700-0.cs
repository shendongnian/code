    public class EmployeesDTO
    {
        List<Employee> NewEmployees { get; set; }
    }
    var employees = new EmployeesDTO(); 
    employees.NewEmployees = csv.LoadEmployees(txtEmployeeMasterFileName.Text)
         .Where(emp => emp.Status.ToUpper() == "A")
         .ToList();
