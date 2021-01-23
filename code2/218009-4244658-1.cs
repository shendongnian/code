    if (!string.IsNullOrEmpty(Security.GetString(Page.Request.Params["VT"]))) {            
        string[] strCntVisit = Security.GetString(Page.Request.Params["VT"]).Split(',');
        foreach (string i in strCntVisit) {
            ListItem item = lstContriesVisited1.Items.FindByValue(i);
            if (item != null) {
                item.Selected = true;
            }
        }                
    }
