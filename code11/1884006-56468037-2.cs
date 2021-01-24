    protected System.Collections.ArrayList Groups
    {
        get
        {
            var al = new System.Collections.ArrayList();
            al.Add(new ListItem("[Select a Group]", ""));
            al.Add(new ListItem("Group A", "A"));
            al.Add(new ListItem("Group B", "B"));
            return al;
        }
    }
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataBind();
        }
    }
    
    protected void Button1_Click(object sender, EventArgs e)
    {
        Label1.Text = iGroup.Text;
        Label2.Text = iGroup.Value;
    }
