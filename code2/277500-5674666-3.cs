    string strWhere = string.Empty;
    if (!string.IsNullOrEmpty(txtName.Text))
            {
                if (!string.IsNullOrEmpty(strWhere))
                    strWhere = " And ";
                strWhere = "Name.StartsWith(\"" + txtName.Text + "\")";
            }
     
            EmployeeDataContext edb = new EmployeeDataContext();
            var emp = edb.Employees.Where(strWhere);
