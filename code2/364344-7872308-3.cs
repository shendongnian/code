    protected void Page_Load(object sender, EventArgs e)
    {
    if (!IsPostBack)
    {
        for (int i = 1; i <= 10; i++)
        {
            cblRounds.Items.Add(new ListItem("Text" + i ,i.ToString()));
        }
    }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
    PrintRounds();
    }
    private void PrintRounds()
    {
        Dictionary<string, string> rondes = new Dictionary<string, string>();
        foreach (ListItem item in cblRounds.Items)
        {
            if (item.Selected)
            {
                rondes.Add(item.Text , item.Value);
                Response.Write("<br/> " + item.Text + " " + item.Value);
            }
        }
             
    }
