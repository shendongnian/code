c#
public Employee GetManager(Employee employee)
{
    Stack<Employee> managers = new Stack<Employee>();
    BuildManagerStack(employee);
    return managers.Peek();
    void BuildManagerStack(Employee e)
    {
        if (employee.ManagerId == null)
        {
            managers.Push(e);
        }
        else
        {
            using (var context = new EmployeeContext())
            {
                var manager = context.Employees.FirstOrDefault(e => e.Id == employee.ManagerId);
                managers.Push(manager);
                BuildManagerStack(manager);
            }
    }
}
I encourage you to try and solve this problem without using recursion: you'll get a cleaner, more readable and more efficient solution :)
