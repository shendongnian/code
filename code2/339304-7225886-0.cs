      string sql = "INSERT INTO checkLog(userID,lineNumber,startTime) VALUES(@ID, @line, @starttime);
            try
            {
                conn.Open();
                comm.CommandText = sql;
                comm.Parameters.Add("ID").Value = cert.userID;
                comm.Parameters.Add("line").Value = lineNumber ;
                comm.Parameters.Add("starttime").Value = startTime ;
                result = comm.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
