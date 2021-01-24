    using (SqlConnection con = new SqlConnection(cs)) {
        using (SqlCommand cmd = new SqlCommand("spAddEmployee", con)) {
    
            string name = txtEmployeeName.Text;
            string gender = ddlGender.SelectedValue;
            int salary = Convert.ToInt32(txtSalary.Text);
    
            SqlParameter op = new SqlParameter("@EmployeeId", SqlDbType.Int);
            op.Direction = System.Data.ParameterDirection.Output;
    
            cmd.CommandType = CommandType.StoredProcedure;
    
            cmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = name;
            //add for your other variables here
            cmd.Parameters.Add(op);
    
            con.Open();
            cmd.ExecuteNonQuery();
         }
    }
