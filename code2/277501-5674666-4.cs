    string condition = string.Empty;
    if (!string.IsNullOrEmpty(txtName.Text))
        condition = string.Format("Name.StartsWith(\"{0}\")", txtName.Text);
     
    EmployeeDataContext edb = new EmployeeDataContext();
    var emp = edb.Employees.Where(condition);
