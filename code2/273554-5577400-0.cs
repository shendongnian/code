       SqlCommand sqlCmd = new SqlCommand("UPDATE table SET param1 = @param1, sqlConn);
    
               
                /* Parameters */
                sqlCmd.Parameters.Add("@param1", SqlDbType.NVarChar);
                sqlCmd.Parameters["@param1"].Value = valuedata;
    
       try
        {
            sqlConn.Open();
            sqlCmd.ExecuteNonQuery();
        }
        catch (SqlException sqlEx)
        {
            sqlErrorLabel.Text = sqlEx.ToString();
            sqlErrorLabel.ForeColor = System.Drawing.Color.Red;
        }
        finally
        {
            sqlConn.Close();
        }
