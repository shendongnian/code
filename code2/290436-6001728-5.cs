    void WebForm1_PreRender(object sender, EventArgs e)
    {
        List<string> list = new List<string>(new[] { "Foo", "Bar", "Tord", "Bob" });
    
        if (!ClientScript.IsClientScriptBlockRegistered("MyScript"))
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("var myArray = new Array();");
            for (int i = 0; i < list.Count; i++)
                sb.AppendLine(string.Format("myArray[{0}] = '{1}';", i, list[i]));
    
            ClientScript.RegisterClientScriptBlock(this.GetType(), "MyScript", sb.ToString(), true);
        }
    }
