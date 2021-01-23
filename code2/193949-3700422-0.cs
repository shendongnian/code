    [Flags]
    public enum ParentDepartments
    {
        None = 0x0,
        Electrical = 0x1,
        Mechanical = 0x2,
        Biology = 0x4,
    }
    public static IList<ParentDepartment> GetParentDepartments(Course course)
    {
        var departments = ParentDepartments.None;
        if (course.ElectricalStudents.Any())
            departments |= ParentDepartments.Electrical;
        if (course.ComputerStudents.Any())
            departments |= ParentDepartments.Electrical;
        if (course.MechanicalStudents.Any())
            departments |= ParentDepartments.Mechanical;
        if (course.BioengineeringStudents.Any())
            departments |= ParentDepartments.Biology;
        return departments;
    }
