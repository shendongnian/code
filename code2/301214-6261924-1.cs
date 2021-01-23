    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            SqlConnection con = new SqlConnection("Data Source=LOCAL;Initial Catalog=Combo;Integrated Security=True");
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT [Text], [Value] FROM [Links]", con);
            DataTable links = new DataTable();
            adapter.Fill(links);
            combo.DataTextField = "Text";
            combo.DataValueField = "Value";
            combo.DataSource = links;
            combo.DataBind();
        }
    }
