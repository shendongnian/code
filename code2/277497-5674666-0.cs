    var predicate = PredicateBuilder.True<employee>();
     
    if(!string.IsNullOrEmpty(txtAddress.Text))
        predicate = predicate.And(e1 => e1.Address.Contains(txtAddress.Text));
    EmployeeDataContext edb= new EmployeeDataContext();
    var emp = edb.Employees.Where(predicate);
