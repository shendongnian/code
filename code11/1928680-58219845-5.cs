            foreach (GridViewRow row in grdRegister.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    EmployeeNo = (row.Cells[1].FindControl("txtEmployeeNumber") as TextBox).Text;
                }
                cmd.Parameters.AddWithValue("@Personnel_Number", EmployeeNo);
                con.Open();
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                con.Close();
                // rest of your loop
            }
