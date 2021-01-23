    for(int i=0; i<Request.Cookies.Count; i++)
    {
        aCookie = Request.Cookies[i];
        output.Append("Name = " + aCookie.Name + "<br />");
        if(aCookie.HasKeys)
        {
            for(int j=0; j<aCookie.Values.Count; j++)
            {
                subkeyName = Server.HtmlEncode(aCookie.Values.AllKeys[j]);
                subkeyValue = Server.HtmlEncode(aCookie.Values[j]);
                output.Append("Subkey name = " + subkeyName + "<br />");
                output.Append("Subkey value = " + subkeyValue + 
                    "<br /><br />");
            }
        }
        else
        {
            output.Append("Value = " + Server.HtmlEncode(aCookie.Value) +
                "<br /><br />");
        }
    }
