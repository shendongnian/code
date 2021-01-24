    var departments = dr["Department"]; //"A--B--C";
    // Split returns string collection of type string[]. 
    string[] deptArray = departments.Split(separator: new[] { "--" }, options: StringSplitOptions.RemoveEmptyEntries);
    // Use ToList on deptArray to get final list.
    List<string> depts = deptArray.ToList();
