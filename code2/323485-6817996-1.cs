    var roleAction = (RoleActionAttribute)typeof(MyViewModel)
        .GetProperty("EmployeeName")
        .GetCustomAttributes(typeof(RoleActionAttribute), true)
        .FirstOrDefault();
    if (roleAction != null)
    {
        var role = roleAction.UserRole;
    }
