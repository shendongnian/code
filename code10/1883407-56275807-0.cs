    if (!Page.IsPostBack)
    {                
        groupingDropDownList.DataSource 
            = sourceList.Select(x => new { x.Name, Value = x });
        groupingDropDownList.DataTextField = "Name";
        groupingDropDownList.DataValueField = "Value";
        groupingDropDownList.DataBind();
    }
    // Actual postback
    else
    {
        var test = groupingDropDownList.SelectedValue;
    }
