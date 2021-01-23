    List<Person> list = new List<Person>();
    // populate the list somehow
    
    if ( !IsPostBack )
    {
        DropDownList ddl = new DropDownList();
        ddl.DataTextField = "Name";
        ddl.DataValueField = "Id";
        ddl.DataSource = list;
        ddl.DataBind();
        
        ddl.SelectedValue = list.Find( o => o.Selected == true ).Id.ToString();
    }
