    CheckBox checkBox1 = (row.Cells[0].FindControl("CheckBox1") as CheckBox);
    string updateData = "update AuditChecklist$ set IsSelected = :@IsSelected";
    SqlConnection con = new SqlConnection(conString);
    con.Open();
    SqlCommand cmd = new SqlCommand(updateData, con); 
    cmd.Parameters.Clear();
    cmd.Parameters.AddWithValue("@IsSelected", checkBox1.Checked ? 1 : 0);
    cmd.ExecuteNonQuery();
    con.Close();
