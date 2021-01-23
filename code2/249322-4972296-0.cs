    var employees = 
        result.Select(x => new Employee {
            EmpID = x.EmpID,
            EmpSalaryDetails = new List<EmpSalaryDetail> {
                new EmpSalaryDetail { 
                    EmpID = x.EmpID,
                    GrossSal = x.GrossSal
                }
            },
            EmpPersonalDetails = new List<EmpPersonalDetail> {
                new EmpPersonalDetail {
                    EmpID = x.EmpID,
                   EmpName = x.EmpName
                }
            }
        );
