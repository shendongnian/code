    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack) {
            bookingTypeList.Items.Insert(0, new ListItem("Project", "p"));
            bookingTypeList.Items.Insert(1, new ListItem("Training", "t"));
            ...
        }
    }
