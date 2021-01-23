      public void functUAD(int intClientID, string TelType, int TelID, string OldTelNumber, string NewTelNumber)
        {
            int ResultTelID = 0 ;
            int TelTypeID ;
            int Result= 0 ;
    
    
            SqlConnection conTel = new SqlConnection();
            conTel.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["CUSTOMERConnectionString"]);
            conTel.Open();
            
            if (TelType.ToLower() == "fax")
    
                TelTypeID = 3;
    
            else if (NewTelNumber.Trim().StartsWith("06") || NewTelNumber.Trim().StartsWith("07"))
    
                TelTypeID = 2;
            else
                TelTypeID = 1;
    
    
    
           if (OldTelNumber != "" && NewTelNumber != "" )    //update old number with new number
            {
                
                           
                SqlCommand cmdUpdateTel = new SqlCommand("uspUpdateClientTel", conTel);
                cmdUpdateTel.CommandType = CommandType.StoredProcedure;
    
                SqlCommand cmdSortNo = new SqlCommand("SELECT sort_no FROM TELEPHONE WHERE tel_id= " + TelID, conTel);
                string SortNo = (string)cmdSortNo.ExecuteScalar();
    
               
                cmdUpdateTel.Parameters.Add(new SqlParameter("@TelID", TelID));
                cmdUpdateTel.Parameters.Add(new SqlParameter("@TelNo", NewTelNumber));
                cmdUpdateTel.Parameters.Add(new SqlParameter("@TelTypeID", TelTypeID));
                cmdUpdateTel.Parameters.Add(new SqlParameter("@DetailsTypeID", 1));
                cmdUpdateTel.Parameters.Add(new SqlParameter("@SortNo", SortNo));
                cmdUpdateTel.Parameters.Add(new SqlParameter("@ResultTelID", ResultTelID));
    
                cmdUpdateTel.ExecuteNonQuery();
                
            }
    
            if (OldTelNumber == "" && NewTelNumber != "")   // add a newnumber
            {
                
                int SortNo = 0 ;
                SqlCommand cmdaddTel = new SqlCommand("uspAddClientTel", conTel);
                cmdaddTel.CommandType = CommandType.StoredProcedure;
    
                
                if (TelTypeID == 1)
                    SortNo = 1;
                else
                {
                    SqlCommand cmdSortNo = new SqlCommand("SELECT MAX(sort_no) from TELEPHONE where tel_id =" + TelID, conTel);
                    int MaxSort = (int)cmdSortNo.ExecuteScalar();
                    SortNo += MaxSort;
                }
                cmdaddTel.Parameters.Add(new SqlParameter("@ClientID", intClientID));
                cmdaddTel.Parameters.Add(new SqlParameter("@TelNo", NewTelNumber));
                cmdaddTel.Parameters.Add(new SqlParameter("@TelTypeID", TelTypeID));
                cmdaddTel.Parameters.Add(new SqlParameter("@DetailsTypeID", 1));
                cmdaddTel.Parameters.Add(new SqlParameter("@SortNo", SortNo ));
                cmdaddTel.Parameters.Add(new SqlParameter("@ResultTelID", ResultTelID));
    
                cmdaddTel.ExecuteNonQuery();
                
            }
    
            if (OldTelNumber != "" && NewTelNumber == "") // delete the old number
            {
                
                SqlCommand cmdDelete = new SqlCommand("RemoveClientTel", conTel);
                cmdDelete.Parameters.Add(new SqlParameter("@TelID",TelID));
                cmdDelete.Parameters.Add(new SqlParameter("@Result", Result));
                cmdDelete.ExecuteNonQuery();
            }
    }
