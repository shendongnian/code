    return studentInfoList
        .Where(item => item.StudentName.Equals(name) 
              && item.StudentID.Equals(id))
        .Select(item => item.Attendance.Count());
----------
    // find student using conditions, suppose it may be only one
    var student = studentInfoList
        .SingleOrDefault(item => item.StudentName.Equals(name)
            && item.StudentID.Equals(id));
    // found
    if (student != null)
    {
        return student.Attendance;
    }
    else
    {
        // not found
    }
