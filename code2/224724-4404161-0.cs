    DirectoryInfo di = default(DirectoryInfo);
            FileInfo[] files = null;
            DataTable dt = new DataTable();
            DataRow dr = null;
            System.DateTime filedate = default(System.DateTime);
            di = new DirectoryInfo(Server.MapPath("~/forms"));
            files = di.GetFiles();
            dt.Columns.Add("name");
            dt.Columns.Add("filepath");
            dt.Columns.Add("filedate");
            foreach (FileInfo inf in files)
            {
                filedate = inf.LastWriteTime;
                dr = dt.NewRow();
                dr["name"] = inf.Name;
                dr["filepath"] = inf.FullName;
                dr["filedate"] = String.Format("{0:MM/dd/yyyy}", filedate);
                dt.Rows.Add(dr);
            }
            DataList1.DataSource = dt;
            DataList1.DataBind();
