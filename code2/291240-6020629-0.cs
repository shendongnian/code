    ScriptManager.RegisterStartupScript(page, page.GetType()
           , "KEY", "updateDockTitle('" + ClientID + "', '" 
                                        + string.Format(format, ChartName.Replace("'", "\'")
                                                   , "No Data To Display") 
                                        + "');".Replace("-", "\\-"), true);
