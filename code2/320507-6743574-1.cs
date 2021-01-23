        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable dtTemp = new DataTable();
            dtTemp.Columns.Add("Column1", typeof(System.String));
            dtTemp.Columns.Add("Column2", typeof(System.String));
            DataRow drRow1 = dtTemp.NewRow();
            drRow1[0] = "Data1";
            drRow1[1] = "Data2";
            dtTemp.Rows.Add(drRow1);
            GridView1.DataSource = dtTemp;
            GridView1.DataBind();
        }
