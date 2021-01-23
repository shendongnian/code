    rdr.Select(r => new DailyEntry
    {
        ID = int.Parse(r["Col_ID"].ToString()),
        Amount = decimal.Parse(r["Col_Amount"].ToString()),
        Date = DateTime.Parse(r["Col_Date"].ToString()),
        Remarks = r["Col_Remarks"].ToString(),
        Site = new Site 
               {
                   SiteID = int.Parse(r["Site_ID"].ToString()),
                   SiteName = r["Site_Name"].ToString()
               }
    }
           
