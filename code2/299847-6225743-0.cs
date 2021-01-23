    public static DataTable dt;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                dt = new DataTable();
                DataRow dr = null;
                dt.Columns.Add(new DataColumn("RowNumber", typeof(string)));
                dt.Columns.Add(new DataColumn("Column1", typeof(string)));
                dt.Columns.Add(new DataColumn("Column2", typeof(string)));         
                dr = dt.NewRow();
                dr["RowNumber"] = 1;
                dr["Column1"] = "column1cell";
                dr["Column2"] = "column2cell";
                dt.Rows.Add(dr);
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
        }
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            if (dt.Rows.Count > 0)
            {
                dt.Rows.RemoveAt(0);
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
        }
