    string[] array_split_item = new string[] { "<script", "</script>", "‘", "’" };
    int pos = 0;
    string strReq = "";
    foreach (string var in Request.QueryString.Keys)
    {
        foreach (string strItem in array_split_item)
        {
            strReq = Request.QueryString[var].ToString();
            pos = strReq.ToLower().IndexOf(strItem.ToLower()) + 1;
            if (pos > 0)
            {
                Response.Write("Some Text");
                Response.End();
            }
        }
    }
