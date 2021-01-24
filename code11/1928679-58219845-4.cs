            cmd.Parameters.Add(new SqlParameter("@Personnel_Number", SqlDbType.[Your SQL Type]));
            foreach (GridViewRow row in grdRegister.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    EmployeeNo = (row.Cells[1].FindControl("txtEmployeeNumber") as TextBox).Text;
                }
                cmd.Parameters["@Personnel_Number"].Value = EmployeeNo;
                con.Open();
                // rest of your loop
            }
