    var departmentGroups = lstStaff.GroupBy(staff => 
        new { staff.DeptID, staff.DepartmentName });
    foreach (var department in departmentGroups)
    {
        var deptNode = new RadTreeNode()
        {
            Value = department.Key.DeptID,
            Text = department.Key.DepartmentName
        };
    
        tvwDepartmentCases.Nodes.Add(deptNode);
    
        foreach (var staffMember in department)
        {
            var staffNode = new RadTreeNode()
            {
                Value = staffMember.StaffID,
                Text = staffMember.StaffName
            };
            deptNode.Nodes.Add(staffNode);
        }
    }
