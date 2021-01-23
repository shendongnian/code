        String path = Server.MapPath("~/[aspx path]");
        string content = File.ReadAllText(path);
        string controlID = "textBox";
        int startIndex = content.IndexOf("<asp:TextBox ID=\"" + controlID + "\"");
        bool foundEndTag = false;
        string controlTag = "";
        int i = startIndex;
        while (!foundEndTag)
        {
            if (content[i] == '>')
                foundEndTag = true;
            controlTag += content[i];
            i++;
        }
 
