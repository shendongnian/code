     protected void Button1_Click(object sender, EventArgs e)
     {
         DataTable dtRecords = new DataTable();
         dtRecords.Columns.Add("FIRSTNAME");
         dtRecords.Columns.Add("LASTNAME");
         dtRecords.Columns.Add("JOB");
         DataRow rw1 = dtRecords.NewRow();
         rw1[0] = "JHON";
         rw1[1] = "SMITH";
         rw1[2] = "MANAGER";
         dtRecords.Rows.Add(rw1);
         DataRow rw2 = dtRecords.NewRow();
         rw2[0] = "MICH";
         rw2[1] = "KEN";
         rw2[2] = "SR MANAGER";
         dtRecords.Rows.Add(rw2);
    
         UploadDataTableToExcel(dtRecords);
    
    }
    protected void UploadDataTableToExcel(DataTable dtRecords)
    {
            string XlsPath = Server.MapPath(@"~/Add_data/test.xls");
            string attachment = string.Empty;
            if (XlsPath.IndexOf("\\") != -1)
            {
                string[] strFileName = XlsPath.Split(new char[] { '\\' });
                attachment = "attachment; filename=" + strFileName[strFileName.Length - 1];
            }
            else
                attachment = "attachment; filename=" + XlsPath;
            try
            {
                Response.ClearContent();
                Response.AddHeader("content-disposition", attachment);
                Response.ContentType = "application/vnd.ms-excel";
                string tab = string.Empty;
                foreach (DataColumn datacol in dtRecords.Columns)
                {
                    Response.Write(tab + datacol.ColumnName);
                    tab = "\t";
                }
                Response.Write("\n");
                
                foreach (DataRow dr in dtRecords.Rows)
                {
                    tab = "";
                    for (int j = 0; j < dtRecords.Columns.Count; j++)
                    {
                        Response.Write(tab + Convert.ToString(dr[j]));
                        tab = "\t";
                    }
                    Response.Write("\n");
                }
                Response.End();
            }
            catch (Exception ex)
            {
                //Response.Write(ex.Message);
            }
    }
