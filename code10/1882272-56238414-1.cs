    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindGrid();
        }
    }
    
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;
        BindGrid();
    }
    
    private void BindGrid()
    {
        List<string> tmp = new List<string>();
        tmp.Add("a");
        GridView1.DataSource = tmp;
        GridView1.DataBind();
    }
    
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        Calendar cal = GridView1.Rows[e.RowIndex].FindControl("Calendar1") as Calendar;
        string tmp = cal.SelectedDate.ToString();
        BindGrid();
    }
