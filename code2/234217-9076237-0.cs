    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindDropDownLists();
        }
    }
    
    protected void Page_Init(object sender, EventArgs e)
    { 
    
            SqlDataSource sqlDS = new SqlDataSource();
            sqlDS.ConnectionString = ConfigurationManager.ConnectionStrings[0].ToString();
            sqlDS.SelectCommand = "select GenderID,Gender from mylookupGender";
            form1.Controls.Add(sqlDS);
    
            DropDownList ddl = new DropDownList();
            ddl.ID = "dddlGender";
            ddl.DataSource = sqlDS;
            ddl.DataTextField = "Gender";
            ddl.DataValueField = "GenderID";
            form1.Controls.Add(ddl);
    
            // ... Repeat above code 9 times or put in a for loop if they're all the same...
    }
    
    private void BindDropDownLists()
    {
        foreach (Control ctl in form1.Controls)
        {
            if (ctl is DropDownList)
            {
                (ctl as DropDownList).DataBind();
            }
        }
    }
