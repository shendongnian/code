    ddlName.DataSource = items.Select(item=>item.Name).Distinct().ToList();
    ddlName.DataBind();
    
    ddlSize.DataSource = items.Select(item=>item.Size).Distinct().ToList();
    ddlSize.DataBind();
    
    ddlPrice.DataSource = items.Select(item=>item.Price).Distinct().ToList();
    ddlPrice.DataBind();
