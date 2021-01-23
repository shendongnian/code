    private void AddEmployee(IEmployee empl)
    {
        if (InvokeRequired)
        {
            this.Invoke(new AddEmployeInvoke(AddEmployee), new Object[] {empl});
        }
        else
        {
            empList.Add(empl); //exception thrown here
        }
    }
