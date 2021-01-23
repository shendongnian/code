    protected void Page_Load(object sender, EventArgs e)
        {
          if (!page.IsPostBack) {
            DataTable myTable = new DataTable();
            myTable.Columns.Add("text", typeof(string));
            myTable.Rows.Add("First Entry");
            myTable.Rows.Add("Second Entry");
    
            GridView1.DataSource = myTable;
            GridView1.DataBind();
          }
        }
