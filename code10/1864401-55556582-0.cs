    // import namespace
    using MoqExpression;
    
    // you should do like this it will work
    mockrepo.Setup(x => x.SearchFor(MoqHelper.IsExpression<Employee>(s => s.Name.Equals("Test")))).Returns(employeeList.AsQueryable());
