    private bool DoesItHasLoops(Dictionary<string, string> departmentWithDepending)
    {
        HashSet<string> checkedDepartments = new HashSet<string>();
        foreach (var department in departmentWithDepending)
        {
            checkedDepartments.Add(department.Key);
            if (HasConflict(department.Value, departmentWithDepending, checkedDepartments))
            {
                return true;
            }
            checkedDepartments.Clear();
        }
        return false;
    }
    private bool HasConflict(string currentDepartment, 
        Dictionary<string, string> departmentWithDepending,
        HashSet<string> checkedDepartments)
    {
        //Checks if this department was already checked, if yes you got a loop
        if (checkedDepartments.Contains(currentDepartment))
        {
            return true;
        }
        else
        {
            //Checks if the current department has a dependency
            if (departmentWithDepending.ContainsKey(currentDepartment))
            {
                //marks the current department as checked and and checks if the department the current department depends on has any conflicts(loops)
                checkedDepartments.Add(currentDepartment);
                return HasConflict(departmentWithDepending[currentDepartment], departmentWithDepending, checkedDepartments);
            }
            else
            {
                return false;
            }
        }
    }
