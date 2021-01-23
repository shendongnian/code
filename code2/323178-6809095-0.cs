    public static bool addData(string storedProcName, string[] dynamicParamName, object[] paramVals, string msg)
    {    
         for (int i = 0; i < dynamicParamName.Length; i++)
         {
              cmd2.Parameters.AddWithValue(dynamicParamName[i], paramVals[i]);
              //cmd2.Parameters.Add(dynamicParamName[i], dynamicParamValues[i]);
         }    
         try
         {
            if (cmd2.Connection.State == ConnectionState.Closed)
            {
                cmd2.Connection.Open();
            }
            int stat = cmd2.ExecuteNonQuery();    
            if (stat > 0)
            {
                res = true;
                msg = "Recorded Added successfully";
                cmd2.Connection.Close();
                cmd2.Dispose();
            }
         }  
    }
