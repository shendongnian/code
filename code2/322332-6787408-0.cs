        System.Data.DataTable dt = new System.Data.DataTable();
        // fill dt
        System.Data.DataTable dtNew = new System.Data.DataTable();
        System.Data.DataRow dr = dtNew.NewRow();
        dr["ValueField"] = String.Empty;
        dr["DisplayField"] = "All";
        dtNew.Rows.InsertAt(dr, 0);
        foreach (var row in dt.Rows)
        {
            dtNew.Rows.Add(row);
        }
