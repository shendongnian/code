    string sHTML = "<a href=\"#\" name=\"xy\">test</a>"; //onclick=\"alert('hello');\"
    int pushAtIndex;
    int index1 = sHTML.ToLower().IndexOf("onclick=");
    if (index1 > 0)
    {
        pushAtIndex = sHTML.IndexOf(";", index1) + 1;
        if (pushAtIndex < 0)
            pushAtIndex = sHTML.IndexOf("\"", index1) + 1;
        if (pushAtIndex < 0)
            pushAtIndex = sHTML.IndexOf("'", index1) + 1;
        if (pushAtIndex > 0)
            sHTML = sHTML.Insert(pushAtIndex, "alert('goodbye');");
    }
    else
    {
        pushAtIndex = sHTML.IndexOf(">");
        if (pushAtIndex > 0)
            sHTML = sHTML.Insert(pushAtIndex, " onclick=\"alert('goodbye');\"");
    }
                    
    MessageBox.Show(sHTML);
