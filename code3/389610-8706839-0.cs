    private static String PreparePOSTForm(string url, NameValueCollection data)
    {
        //Set a name for the form
        string formID = "PostForm";
        //Build the form using the specified data to be posted.
        StringBuilder f = new StringBuilder();
        f.Append("<form id=\"" + formID + "\" name=\"" + 
                       formID + "\" action=\"" + url + 
                       "\" method=\"POST\">");
    
        foreach (string key in data)
        {
            f.Append("<input type=\"hidden\" name=\"" + key + 
                           "\" value=\"" + data[key] + "\">");
        }
    
        f.Append("</form>");
        //Build the JavaScript which will do the Posting operation.
        StringBuilder s = new StringBuilder();
        s.Append("<script language="'javascript'">");
        s.Append("var v" + formID + " = document." + 
                         formID + ";");
        s.Append("v" + formID + ".submit();");
        s.Append("</script>");
        //Return the form and the script concatenated.
        //(The order is important, Form then JavaScript)
        return f.ToString() + s.ToString();
    }
