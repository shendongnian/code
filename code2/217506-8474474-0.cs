           //  private String connectionString = null;
       // private SqlConnection sqlConnection = null;
       
            btnBack.Enabled = true;
            sqlConnection.Open();
            dataGridView1.DataSource = bindingSource;
           
            //cmd = new SqlCommand("update empinfo set empname=@empname, empAdd=@empAdd, empMobile=@empMobile where empid=@empid", con);
            cmd = new SqlCommand("empinfo_Insert_Update_Delete", sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd1 = new SqlCommand("Insert_Update_Delete_EmpSal", sqlConnection);
            cmd1.CommandType = CommandType.StoredProcedure;
            try
            {
                cmd.Parameters.AddWithValue("@empid", txtempId.Text);
                cmd.Parameters.AddWithValue("@empName", txtempName.Text);
                cmd.Parameters.AddWithValue("@empAdd", txtempAdd.Text);
                cmd.Parameters.AddWithValue("@empMobile", TxtempMobile.Text);
                cmd.Parameters.AddWithValue("@intflag", 1);
                //txtempId.Text = txtsalempId.Text;
                cmd1.Parameters.AddWithValue("@salId", txtsalId.Text);
                cmd1.Parameters.AddWithValue("@salAmount", txtsalary.Text);
                cmd1.Parameters.AddWithValue("@salDate", txtdos.Text);
                cmd1.Parameters.AddWithValue("@empId", txtempId.Text);
                cmd1.Parameters.AddWithValue("@intflag", 1);
                cmd.ExecuteNonQuery();
              
                cmd1.ExecuteNonQuery();
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    dataTable.Rows[i][3] = dataTable.Rows[0][3];
                }
               
                sqlDataAdapter.Update(dataTable);
                //int b;
                //b = int.Parse(txtempId.Text);
                //selectQueryString1 = "SELECT * FROM empsal where empid=" + b;
                ////sqlDataAdapter1 = new SqlDataAdapter(selectQueryString1, sqlConnection);
                ////sqlCommandBuilder1 = new SqlCommandBuilder(sqlDataAdapter1);
                ////dataTable1 = new DataTable();
                ////sqlDataAdapter1.Fill(dataTable1);
                ////bindingSource1 = new BindingSource();
                ////bindingSource1.DataSource = dataTable1;
                ////dataGridView1.DataSource = bindingSource1;
                MessageBox.Show("data Updated");
            }
            catch (Exception exceptionObj)
            {
                MessageBox.Show(exceptionObj.Message.ToString());
            }                    
            cmd1 = null;            
            dataGridView1.DataSource = null;
            sqlConnection.Close();
            clearText();
           
           
            addcolumn();
            childform();
        }
