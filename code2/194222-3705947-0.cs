    newEmployee.title = ifNotNull(title);
    ....
    ....
    newEmployee.Office = ifNotNull(office);
    
    public string ifNotNull(string)
    {
    if(string.Length >0)
    return HttpUtility.HtmlEncode(title);
    else 
    return "";
    }
