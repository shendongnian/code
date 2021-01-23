    pn.DataSource = Datatbl.Tables["datalist"];
    pn.DataValueField = "partnumber";
    pn.DataTextField = "partnumber";
    pn.DataBind();
    pn.Items.Insert(0, "");
    
    if (!Convert.IsDBNull(ligne["pn"])
    {
        pn.SelectedValue = ligne["pn"].ToString();
    }
    else
    {
        pn.SelectedIndex = 0;
    }
