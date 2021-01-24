    int pcount = 1;
    // This is where we keep the placeholder text for the parameters 
    List<string> names = new List<string>();
    // This is the list of parameters built using the checkboxes checked state
    List<SqlParameter> prms = new List<SqlParameter>();
    foreach (CheckBox cb in flowLayoutPanel1.Controls)
    {
        if (cb.Checked)
        {
            names.Add("@p" + pcount);
            prms.Add(new SqlParameter 
            {
                ParameterName = "@p" + pcount, 
                SqlDbType = SqlDbType.NVarChar, 
                Value = cb.Text,
                // For performance it would be useful also to specify the column size
                // Size = 100,
            });
            pcount++;
        }
    }
    // Build the sql command adding all the parameters placeholders inside an IN clause
    string cmdText = @"SELECT JOB_HEADER.P FROM JOB_HEADER WHERE JOB_HEADER.MODE_F IN(";
    cmdText += string.Join(",", names) + ")";
    SqlCommand command = new SqlCommand(cmdText, connection);
    // Give the parameters collection to the command
    command.Parameters.AddRange(prms.ToArray());
