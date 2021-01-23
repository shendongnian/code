    static void GenerateReport()
    {  
        string[] arrTypes = ReadReport().Split('~');
                
        foreach (string strReportType in arrTypes)
        {
            if (strReportType == "BillingReport")
            {
                while (ThisReader.Read())
                {
                    crRpt.SetParameterValue("@CollectionStartDate", ThisReader["StartDate"]);
                    crRpt.SetParameterValue("@CollectionEndDate", ThisReader["EndDate"]);
                    crRpt.SetParameterValue("@SpokeCode", ThisReader["SpokeCode"]);
                }
            }           
        }
    }
    static string ReadReport()
    {
        try
        {
            ………		
            using (SqlDataReader reader = thisCommand.ExecuteReader())
            {
                while (reader.Read())
                {
                    strReturn += reader["TypeOfReport"].ToString() + "~";
                }
                reader.Close();
            }
            strReturn = strReturn.Remove(strReturn.Length - 1);                
        }
        catch (Exception ex)
        {  }
        finally
        {  }
        return strReturn;
    }
