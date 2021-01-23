      protected void gvLocationBoard_DataBound(object sender, EventArgs e)
        {
            //Show the headers for the Period Times directly from sdsRollCallPeriods
            DataSourceSelectArguments dss = new DataSourceSelectArguments();
            DataView dv = sdsRollCallPeriods.Select(dss) as DataView;
            DataTable dt = dv.ToTable() as DataTable;
            if (dt != null)
            {
                int wsPos = 0;
                int wsCol = 3;  //start of PeriodTimes column in gvLocationBoard
                foreach (DataRow dr in dt.Rows)
                {
                    gvLocationBoard.Columns[wsCol + wsPos].HeaderText = dr.ItemArray[1].ToString();
                    gvLocationBoard.Columns[wsCol + wsPos].Visible = !gvLocationBoard.Columns[wsCol + wsPos].HeaderText.StartsWith("RollCallPeriod");
    
                    wsPos += 1;
                }
            }
        }
