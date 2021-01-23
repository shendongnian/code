    private string PrepareDataSet(int LAST_TRIAL_USER_DETAIL_ID)
        {
            System.Data.SqlClient.SqlConnection conn = new SqlConnection("my connection string");
            string _cmdText = "Select TOP 10 TRIAL_USER_DETAIL_ID,Convert(Varchar,TRIAL_ACTIVATE_DATE,103) ActivateDate,TRIAL_CD_SERIAL_NO From TDSMAN_TRIAL_USER_DETAIL Where TRIAL_USER_DETAIL_ID >" + LAST_TRIAL_USER_DETAIL_ID;
    
            SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(_cmdText, conn);
            DataSet ds = new System.Data.DataSet();
            da.Fill(ds,  "User_Detail");
            //get the previous data from chche
            var parentDt = (DataSet)_cache["key For previous data in cache"];
            ds.Merge(parentDt);  
            tblUserDetail.DataSource = ds;
            tblUserDetail.DataBind();  
            
            //Notes:
            //-you don't need to build rows you just bind the new ds to the gridview.
            //-when you get the first data on page load save the data into the cache or 
            //any state management variables.
        }
