    private void CreateEmpList(SPHttpClient client)
    {
        // the rest of the code
    
        EmpList = SortedList.OrderBy(o => o.Name).ToList();
        foreach(var employee in EmpList)
        {
            employee.SetLocation();
        }
    }
