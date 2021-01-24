    public DataTable getLinq(DataTable dt1, DataTable dt2)
            {
                DataTable dtMerged = (from a in dt1.AsEnumerable()
                                      join b in dt2.AsEnumerable()
                                      on a["code"].ToString() equals b["code"].ToString()
                                      into g
                                      where g.Count() > 0
                                      select a).CopyToDataTable();
     
                return dtsimilar;
            }`
    
           set dtsimilar as data source for  third grid
