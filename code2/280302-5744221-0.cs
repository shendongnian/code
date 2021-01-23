    foreach (GridViewRow row in GridView2.Rows)
        {
        CheckBox AttendanceCheckBox = row.FindControl("AttendanceCheckBox") as CheckBox;
        if (AttendanceCheckBox != null)
        {
           try
           {                
               connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["RegisterConnectionString"].ConnectionString);
               SqlCommand command = new SqlCommand("INSERT INTO Attendance(Present, StudentID, LessonID) VALUES(@AttendanceChecked, @StudentID, @LessonID)");
               command.Parameters.AddWithValue("@AttendanceCheck",AttendanceCheckBox.Checked);
