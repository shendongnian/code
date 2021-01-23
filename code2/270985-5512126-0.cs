     protected void Button1_Click(object sender, EventArgs e)
    {
        if (FileUpload1.HasFile)
        {
            if (Session["dtbl"] == null)
            {
                DataTable dtbl = new DataTable();
                DataColumn FileName = new DataColumn("FileName", System.Type.GetType("System.String"));
                dtbl.Columns.Add(FileName);
                Session["dtbl"] = dtbl;
            }
            DataTable dtbl = (DataTable)Session["dtbl"];
            DataRow myRow;
            myRow = dt.NewRow();
            myRow["FileName"] = FileUpload1.FileName;
            dtbl.Rows.Add(myRow);
            gridView1.DataSource = dtbl.DefaultView;
            gridView1.DataBind();
            Session["dtbl"] = dtbl;
        }
    }
