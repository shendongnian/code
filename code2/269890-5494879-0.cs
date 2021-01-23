            #region SaveButton
            System.Data.SqlClient.SqlDataAdapter da;
            string sql = "SELECT * From tblWorkers";
            da = new System.Data.SqlClient.SqlDataAdapter(sql, con);
            
            System.Data.SqlClient.SqlCommandBuilder cb;
            cb = new System.Data.SqlClient.SqlCommandBuilder (da);
            //add to Dataset a new row
            DataRow dRow = ds1.Tables["Workers"].NewRow();
            //add data to the new row just have been created
            //refer to first_Name
            dRow[1] = textBox1.Text;
            dRow[2] = textBox2.Text;
            dRow[3] = textBox3.Text;
            //add command
            //add to table worker a new row that declared by row variable name dRow
            ds1.Tables["Workers"].Rows.Add(dRow);
            MaxRows = MaxRows + 1; //to enable last row is still last row
            inc = MaxRows - 1;
            //call data adapter da to update and save data into database sql server
            da.Update(ds1, "Workers");              
                       
            MessageBox.Show("Entry Added!");
            con.Close();
            #endregion 
