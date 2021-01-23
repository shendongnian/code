    private void btnDeleteEmployee_MouseDown(object sender, MouseEventArgs e)
    {
        if (item.GetType() == emp.GetType())
        {
           emp = EmployeeRepository.GetById(((Employee)beEmployees.Current).Id);
           EmployeeRepository.Delete(emp);
        }            
    }
