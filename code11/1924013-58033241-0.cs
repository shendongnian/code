public class EmployeesBL
{
    public IEnumerable<Employee> GetAll()
    {
        using(var employeesDa = new EmployeesDA())
        {
            return employeesDa.GetAll();
        }
    }
    public Employee GetById(int id)
    {
        using(var employeesDa = new EmployeesDA())
        {
            return employeesDa.GetById(id);
        }
    }
}
3. In the code in the linked question, in the line: `return new MyClass().SetName("some name");`, the `new MyClass()` is an explicit instantiation (if that's what you were asking about).
