    Adapter.Fill(Data, "Employees");
    var employees = new List<Employee>();
    foreach(var row in Data.Tables[1].Rows)
    {
        var employee = new Employee();
        employee.ID = Convert.ToInt32(row["ID"].ToString());
        employee.FullName = row["FullName"].ToString();
        employees.Add(employee);
    }
    ListEmployee.DataContext = employees;
