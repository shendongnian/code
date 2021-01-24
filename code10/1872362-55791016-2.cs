    var sql = @"UPDATE CurrentStudent 
    SET CurrentStudent.DateOfJoining =@joinDate
        CurrentStudent.DateOfLeaving = @leaveDate,
        CurrentStudent.Course = ''
    FROM CurrentStudent SI INNER JOIN UserDetails UI ON SI.Email = UI.Email";
    using(var conn=new SqlConnection(...))
    using(var cmd=new SqlCommand(sql,conn);
    {
        var joinDate=cmd.Parameters.Add("@joinDate",SqlDbType.Date);
        var leaveDate=cmd.Parameters.Add("@leaveDate",SqlDbType.Date);
        //Set a DateTime, not a string
        joinDate.Value=joinDaterPicker.Value;
        leaveDate.Value=leaveDatePicker.Value;
        conn.Open();
        cmd.ExecuteNonScalar();
    }
