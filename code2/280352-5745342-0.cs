     foreach (GridViewRow row in GridView2.Rows)
    {
        if (((CheckBox)row.FindControl("AttendanceCheckBox")).Checked)
        {
    Int32 StudentID = Convert.ToInt32(((Label)row.FindControl("studentIDLabel")).Text)
    ....
    ....
    }
