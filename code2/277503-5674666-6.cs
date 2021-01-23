    string condition = string.Empty;
    if (!string.IsNullOrEmpty(txtName.Text))
        condition = string.Format("Name.StartsWith(\"{0}\")", txtName.Text);
     
    EmployeeDataContext edb = new EmployeeDataContext();
    if(condition != string.empty)
    {
      var emp = edb.Employees.Where(condition);
     ///do the task you wnat
    }
    else
    {
     //do the task you want 
    }
