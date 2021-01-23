    [WebMethod]
    public string[] GetInfo(string prefixText, string contextKey)
    {
        DataSet dtst = new DataSet();                        
        SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
        string strSql = "";
        
        if (contextKey == "Country")
        {                        
            strSql = "SELECT CountryName FROM Tbl_ooo WHERE CountryName LIKE '" + prefixText + "%' ";              
        }
        else if(contextKey == "Companies")
        {
            strSql = //Other SQL Query
        }
    
        SqlCommand sqlComd = new SqlCommand(strSql, sqlCon);                        
        sqlCon.Open();                        
        SqlDataAdapter sqlAdpt = new SqlDataAdapter();
        sqlAdpt.SelectCommand = sqlComd;                        
        sqlAdpt.Fill(dtst);                        
        string[] cntName = new string[dtst.Tables[0].Rows.Count];                        
        int i = 0;                        
        try                        
        {                            
           foreach (DataRow rdr in dtst.Tables[0].Rows)                            
           {                                
              cntName.SetValue(rdr[0].ToString(),i);
              i++;                            
           }                        
        }
        catch { }                        
        finally                        
        {
            sqlCon.Close();                        
        }                        
        return cntName; 
    }
  
