    List<HtmlGenericControl> tbodies = new List<HtmlGenericControl>{/*Populate your list here*/};
    foreach (HtmlGenericControl tbody in tbodies)
    {
        if (tbody.Attributes["version"] != null)
        {
            if (tbody.Attributes["version"] == ver)
            {
                tbody.Style.Add(HtmlTextWriterStyle.Display, "");
            } /*Probably actually don't need the else statment
            else
            {
                pnl.Style.Add(HtmlTextWriterStyle.Display, "none"); 
            }
           */
        }
    }
