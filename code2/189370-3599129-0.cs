    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Col1");
            dt.Columns.Add("Col2");
            dt.Columns.Add("Col3");
            for (int i = 0; i < 20; i++)
            {
                DataRow dr = dt.NewRow();
                dr["Col1"] = string.Format("Row{0}Col1", i + 1);
                dr["Col2"] = string.Format("Row{0}Col2", i + 1);
                dr["Col3"] = string.Format("Row{0}Col3", i + 1);
                dt.Rows.Add(dr);
            }
            GridView1.DataSource = dt;
            GridView1.DataBind();
            SetButtonState();
        }
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        SetButtonState();
    }
    private void SetButtonState()
    {
        btactivate.Visible = GridView1.SelectedIndex > -1;
        btdeactivate.Visible = GridView1.SelectedIndex > -1;
    }
