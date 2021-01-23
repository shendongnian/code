    cmd = new OracleCommand("abstract_names.copy_account", conn);
    
    cmd.Parameters.Add("r_rows_copied", OracleType.Int32).Direction = ParameterDirection.Output;
    cmd.Parameters.Add("ar_from_acct", OracleType.VarChar).Value = accountNumberDropDownList.SelectedValue.ToString();
    cmd.Parameters.Add("ar_to_acct", OracleType.VarChar).Value = copyAccountDDL.SelectedValue.ToString();
    cmd.CommandType = CommandType.StoredProcedure;
    cmd.ExecuteNonQuery();
    conn.Close();
