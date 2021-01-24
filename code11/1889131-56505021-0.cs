    int lstInsSubjId = -1;
    
    try
    {
        using (SqlConnection con = new SqlConnection(connectionString))
        {
            con.Open();
            SqlCommand cmd = connection.CreateCommand();
            SqlTransaction tran = con.BeginTransaction("Transaction1");//Transaction begin
            cmd.Connection = cmd;
            cmd.Transaction = tran;
            tran.Save("Savepoint_1");//Savepoint 1
    
            cmd.CommandText = @"insSubject";
            cmd.Parameters.Add("@lstInsSubjId", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@sub_name", SqlDbType.VarChar).Value = txtSubjectName.Text.Trim();
    
            cmd.CommandType = CommandType.StoredProcedure;
            tran.Save("Savepoint_2");//Savepoint 2
    
            cmd.ExecuteNonQuery();
    
            lstInsSubjId = Convert.ToInt32(cmd.Parameters["@lstInsSubjId"].Value);
    
            for (int i = 0; i < clbClasses.CheckedItems.Count; i++)
            {
                int clsId = Convert.ToInt32(((DataRowView)clbClasses.CheckedItems[i]).Row["c_id"].ToString());
                SqlCommand cmd2 = connection.CreateCommand();
                cmd2.Connection = cmd2;
                cmd2.Transaction = tran;
                cmd2.CommandText = @"INSERT INTO tblClassSubjectMap_mavis(c_id, sub_id) 
                                    VALUES(@c_id, @sub_id)";
                cmd2.Parameters.Add("@c_id", SqlDbType.Int).Value = clsId;
                cmd2.Parameters.Add("@sub_id", SqlDbType.Int).Value = lstInsSubjId;
    
                cmd2.CommandType = CommandType.Text;
                //tran.Save("Savepoint_3");//Savepoint 3
    
                cmd2.ExecuteNonQuery();
            }
    
            tran.Commit();//Transaction commit
