    object readonly syncRootEmployee = new object();
    List<Employee> employeeList = null;
    List<EmployeePhoto> employeePhotoList = null;
    public void AddEmployee(Employee employee, List<EmployeePhoto> photos)
    {
        lock (syncRootEmployee)
        {
            if (employeeList == null)
            {
                employeeList = new List<Employee>();
            }
            if (employeePhotoList == null)
            {
                employeePhotoList = new List<EmployeePhoto>();
            }
            employeeList.Add(employee);
            foreach(EmployeePhoto ep in photos)
            {
                employeePhotoList.Add(ep);
            }
        }
    }
