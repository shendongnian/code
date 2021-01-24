    DropDownList ddlSize = item.FindControl("ddlSize") as DropDownList;
    DropDownList ddlCrust = item.FindControl("ddlCrust") as DropDownList;
    //ArrayList prodSize = new ArrayList(); /redundant
    //ArrayList prodCrust = new ArrayList();
    var prodSize = Session["prodSize"] as ArrayList;
    var prodCrust = Session["prodCrust"] as ArrayList;
    if(prodSize != null && ddlSize != null && ddlSize.SelectedValue != null)
        prodSize.Add(ddlSize.SelectedValue); // makes no sense .ToString();
    if(prodCrust != null && ddlCrust != null && ddlCrust.SelectedValue != null)
        prodCrust.Add(ddlCrust.SelectedValue); // see above .ToString();
