    protected void Page_Load(object sender, EventArgs e)
    {   
        if (!Page.IsPostBack)
        {
            DataAccessObj daObj = new DataAccessObj();
    
            foreach (ReportedByItem repByItem in daObj.GetAllReportedBy())
            {
                ListItem listItem = new ListItem(repByItem.Name, repByItem.Id.ToString());
                combobox.Items.Add(listItem);
            }
    
            IncidentGrid.DataSource = daObj.GetIncidentsByReportedById(0);
            IncidentGrid.DataBind();
        }
    }
