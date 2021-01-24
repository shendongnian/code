    var sql = @"UPDATE CurrentStudent 
    SET CurrentStudent.DateOfJoining =@joinDate
        CurrentStudent.DateOfLeaving = @leaveDate,
        CurrentStudent.Course = ''
    FROM CurrentStudent SI INNER JOIN UserDetails UI ON SI.Email = UI.Email";
    using(var conn=new SqlConnection(...))
    {
        conn.Execute(sql,new { joinDate  = joinDaterPicker.Value, 
                               leaveDate = leaveDatePicker.Value});
    }
