    var employees = new ObservableCollection<Employee>() { 
        new Employee() {ID=1, Department="NET", Salary=5000, Joindate=new DateTime(2011,04,08)},
        new Employee() {ID=2, Department="NET", Salary=6000, Joindate=new DateTime(2011,04,07)},
        new Employee() {ID=3, Department="JAVA", Salary=7000, Joindate=new DateTime(2011,04,08)},
        new Employee() {ID=4, Department="JAVA", Salary=8000, Joindate=new DateTime(2011,04,07)},
        new Employee() {ID=5, Department="NET", Salary=9000, Joindate=new DateTime(2011,04,06)}
    };
    var distinctDates = employees.Select(j => j.Joindate).Distinct().OrderByDescending(d => d);
    var salaryByDepartmentAndJoindate = distinctDates.Select(d => pivot(employees.Where(jd => jd.Joindate == d)));
    var result = new ObservableCollection<dynamic>(salaryByDepartmentAndJoindate);
