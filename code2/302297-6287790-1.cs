    private static string[] names = new string[] { "Matt", "Joanne", "Robert" };
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            BindGrid();
        }
    }
    private void BindGrid()
    {
        DataGrid1.DataSource = names;
        DataGrid1.DataBind();
    }
    protected void DataGrid1_DeleteCommand(object source, DataGridCommandEventArgs e)
    {
        string deletedItem = ((Label) DataGrid1.Items[e.Item.ItemIndex].FindControl("lblItems")).Text;
        names = names.Where(val => val != deletedItem).ToArray();
        BindGrid();
    }
