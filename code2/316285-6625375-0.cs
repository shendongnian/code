    ddlColor.DataSource = from p in db.ProductTypes
                                      where p.ProductID == pID
                                      orderby p.Color 
                                      select new { p.Color };
    ddlColor.DataTextField = "Color";
    ddlColor.DataBind();
    ddlColor.Items.Add(new ListItem("Select", "NA");
