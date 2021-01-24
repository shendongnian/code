    public override void CreateNewOutputRows()
        {
            DataTable dt = (DataTable)Variables.FileList;
            foreach (DataRow dr in dt.Rows)
            {
                Output0Buffer.AddRow();
                Output0Buffer.FileName = (String)dr[0];
                Output0Buffer.FileDate = (DateTime)dr[1];
                Output0Buffer.FileSize = Convert.ToInt32(dr[2]);
                Output0Buffer.DownloadDate = DateTime.UtcNow;
    
            }
        }
    
