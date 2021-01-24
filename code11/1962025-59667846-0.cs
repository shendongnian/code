    [HttpPost, ValidateAntiForgeryToken]
    public ActionResult UpdateDevelopmentRequest(int changeID, string evaluator, int priority, string status)
        {
            using (var conn = new SqlConnection(<your_connection_string_goes_here>))
            using (SqlCommand cmd = new SqlCommand(StoredProcedures.DevRequests.UpdateDevRequest, Conn))
            {           
                 cmd.CommandType = CommandType.StoredProcedure;
    
                 /*
                 cmd.Parameters.Add("@changeID", SqlDbType.Int).Value = changeID;
                 cmd.Parameters.Add("@evaluator", SqlDbType.NVarChar, 30).Value = evaluator;
                 cmd.Parameters.Add("@priority", SqlDbType.Int).Value = priority;
                 cmd.Parameters.Add("@status", SqlDbType.NVarChar, 15).Value = status;
                 */
    
                 var param1 = cmd.Parameters.AddWithValue("@changeID", changeID);
                 cmd.Parameters["@changeID"].Direction = ParameterDirection.Input
                 param1.SqlDbType = SqlDbType.Int
                 var param2 = cmd.Parameters.AddWithValue("@evaluator", evaluator);
                 cmd.Parameters["@evaluator"].Direction = ParameterDirection.Input
                 param2.SqlDbType = SqlDbType.NVarChar
                 var param3 = cmd.Parameters.AddWithValue("@priority", priority);
                 cmd.Parameters["@priority"].Direction = ParameterDirection.Input
                 param3.SqlDbType = SqlDbType.Int
                 var param4 = cmd.Parameters.AddWithValue("@status", status);
                 cmd.Parameters["@status"].Direction = ParameterDirection.Input
                 param4.SqlDbType = SqlDbType.NVarChar
    
                 Conn.Open();
                 // If you want you can specify the Timeout as below
                 // cmd.CommandTimeout = 300;
                 cmd.ExecuteNonQuery();
                 Conn.Close();
            }
            return RedirectToAction("DevelopmentRequests");
        }
