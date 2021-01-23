    ClientScriptManager csm;
    StringBuilder sb;
    string stringToAppend;
    int currentPage;
    
    csm = Page.ClientScript;
    sb = new StringBuilder();
    
    // headers
    foreach (DataControlField dcf in gvClass.Columns)
    {
        sb.Append(dcf.HeaderText + "\t");
    }
    
    sb.Append("\\n");
    currentPage = gvClass.PageIndex;
    
    for (int i = 0; i < gvClass.PageCount; i++)
    {
        gvClass_PageIndexChanging(null, new GridViewPageEventArgs(i));
    
        foreach (GridViewRow gvr in gvClass.Rows)
        {
            foreach (TableCell tc in gvr.Cells)
            {
                if (tc.Controls.Count > 0)
                {
                    stringToAppend = ((LinkButton)tc.Controls[0]).Text;
                    sb.Append(PRTL_UtilityPackage.FormatHtmlCharacters(stringToAppend) + " \t");
                }
                else
                {
                    stringToAppend = tc.Text;
                    sb.Append(PRTL_UtilityPackage.FormatHtmlCharacters(stringToAppend) + " \t");
                }   
            }
            sb.Append("\\n");
        }
    }
    
    gvClass_PageIndexChanging(null, new GridViewPageEventArgs(currentPage));
    
    // Javascript that sets the clipboard to the stringbuilders value
    csm.RegisterClientScriptBlock(typeof(Page), "copy",
    "<script language=\"javascript\" type=\"text/javascript\"> " +
    "window.clipboardData.setData(\"Text\", \"" + sb.ToString() + "\"); " +
    "</script>");
