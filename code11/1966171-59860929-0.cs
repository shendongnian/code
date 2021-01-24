    var empCode = Convert.ToInt32(txtEmpCode.Text);
    var IsActive = db.tblEmployeeDatas.FirstOrDefault(e => e.EmployeeCode == empCode);
    if (IsActive == null)
    {
       IsActive = new database.tblEmployeeData
       {
          EmployeeCode = empCode,
       };
    }
    IsActive.IsActive = cbxResignationEmp.Checked = true, // BTW should it be assigning or condition?
    db.tblEmployeeDatas.AddOrUpdate(IsActive);
    db.SaveChanges();
    ...
    
