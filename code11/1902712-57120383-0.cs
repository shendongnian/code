protected void stateDropDownList_PreRender(object sender, EventArgs e)
    {
        if (IsPostBack == false)
        {
            if (RouteData.Values["state"] != null)
            {
                TextInfo stateti = new CultureInfo("en-US", true).TextInfo;
                string xstate = RouteData.Values["state"].ToString().Replace("-", " ");
                xstate = stateti.ToTitleCase(xstate);
                stateDropDownList.SelectedValue = xstate;
            }
        }
    }
