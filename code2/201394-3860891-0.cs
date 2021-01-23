    var depts = from staff in lstStaff
                where !string.IsNullOrEmpty(staff.DepartmentName)
                group   //staff nodes
                    new RadTreeNode  //each item in the group is a node
                    {
                        Value = staff.StaffID,
                        Text = staff.StaffName,
                    }
                by      //departments
                    new
                    {
                        staff.DeptID,
                        staff.DepartmentName,
                    };
    foreach (var dept in depts)
    {
        var deptNode = new RadTreeNode
        {
            Value = dept.Key.DeptID,
            Text = dept.Key.DepartmentName,
        };
        deptNode.Nodes.AddRange(dept.ToArray());
        tvwDepartmentCases.Nodes.Add(deptNode);
    }
