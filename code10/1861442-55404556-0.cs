    Person personAlias = null;
    Employee employeeAlias = null;
    EmployeeAgeViewModel result = null;
    var temp = _session.QueryOver<Employee>(() => employeeAlias)
        .JoinQueryOver(x => x.Person, () => personAlias)
        .SelectList(
            list => list
            .Select(x => personAlias.FirstName).WithAlias(() => result.FirstName)
            .Select(x => personAlias.LastName).WithAlias(() => result.LastName)
            .Select(x => x.Gender).WithAlias(() => result.Gender)
            .Select(x => x.BirthDate).WithAlias(() => result.BirthDate)
            .Select(x => x.HireDate).WithAlias(() => result.HireDate)
            .Select(DateProjections.DateDiff("yy", () => employeeAlias.BirthDate, () => DateTime.Now))
                .WithAlias(() => result.Age)
            )
        .TransformUsing(Transformers.AliasToBean<EmployeeAgeViewModel>())
        .List<EmployeeAgeViewModel>();
    return temp.ToList();
