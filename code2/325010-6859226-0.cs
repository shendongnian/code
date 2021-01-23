    public static Department GetDepartment(string employeeIdOrDepartmentName) {
        if (LooksLikeEmployeeID(employeeIdOrDepartmentName))
            return GetDepartmentByEmployeeID(employeeIdOrDepartmentName);
        else
            return GetDepartmentByDepartmentName(employeeIdOrDepartmentName);
    }
    private static Department GetDepartmentByEmployeeID(string employeeId) {
        /* ... */
    }
    private static Department GetDepartmentByDepartmentName(string departmentName) {
        /* ... */
    }
