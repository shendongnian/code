    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    sb.Append("<script language=\"javascript\">");
                    sb.Append("confirm(\"Some Message\")");
                    sb.Append("</script>");
    ScriptManager.RegisterStartupScript(
                                 page, 
                                 page.GetType(),  
                                 "Alert", 
                                 sb.ToString(), 
                                 true);
