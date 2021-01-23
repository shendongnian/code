        SqlCommand cmd2 = new SqlCommand();
        cmd2.Connection = conn;
        cmd2.CommandType = System.Data.CommandType.StoredProcedure;
        cmd2.CommandText = "dbo.Number_Of_Correct";
                
        SqlParameter sp0 = new SqlParameter("@Return_Value", System.Data.SqlDbType.SmallInt);
        sp0.Direction = System.Data.ParameterDirection.ReturnValue;
        SqlParameter sp1 = new SqlParameter("@QuestionID", System.Data.SqlDbType.SmallInt);
        cmd2.Parameters.Add(sp0);
        cmd2.Parameters.Add(sp1);
        sp1.Value = 3;
                
        cmd2.ExecuteScalar();     // int Result = (int)cmd2.ExecuteScalar();  trowns System.NullReferenceException
        MessageBox.Show(sp0.Value.ToString());
