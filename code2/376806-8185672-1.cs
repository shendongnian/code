    cmd = new OracleCommand("abstract_names.copy_account", conn);                      
    cmd.Parameters.Add("r_rows_copied", OracleType.Int32).Direction = ParameterDirection.Output;
    cmd.Parameters.Add("ar_old_acct ", OracleType.VarChar).Value = accountNumberDropDownList.SelectedValue.ToString();
    cmd.Parameters.Add("ar_new_acct", OracleType.VarChar).Value = copyAccountDDL.SelectedValue.ToString();
    cmd.CommandType = CommandType.StoredProcedure;
    object value = cmd.ExecuteScalar();
    conn.Close();
