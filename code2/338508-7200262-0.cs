            var predicate = PredicateBuilder.True();
    
            if(!string.IsNullOrEmpty(txtAddress.Text))
                predicate = predicate.And(e1 => e1.Address.Contains(txtAddress.Text));
            if (!string.IsNullOrEmpty(txtEmpId.Text))
                predicate = predicate.And(e1 => e1.Id == Convert.ToInt32(txtEmpId.Text));
         
    
            EmployeeDataContext edb= new EmployeeDataContext();
            var emp = edb.Employees.Where(predicate);
            grdEmployee.DataSource = emp.ToList();
            grdEmployee.DataBind();
