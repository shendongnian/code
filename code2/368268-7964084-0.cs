    if (!string.IsNullOrEmpty(txtWaitedDate.Text)) {
        SqlParameter parameter = cmdTwMainEntry.Parameters.Add("@scmDate", System.Data.SqlDbType.DateTime);
            // Set the value.
            parameter.Value = Convert.ToDateTime(txtWaitedDate.Text);
    }   
