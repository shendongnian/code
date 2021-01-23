    protected void Page_Load(object sender, EventArgs e) {
    
        ...
        if (!IsPostBack)
        {
            filteroptions.DataSource = ds;
            filteroptions.DataTextField = "Iteration";
            filteroptions.DataValueField = "ProjectIterationID";
            filteroptions.DataBind();
            filteroptions.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Entire Project", "0"))l
        }
    }
