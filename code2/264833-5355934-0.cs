    if(!e.Data.Contains("Query:"))
    {
        e.Data.Add("Query:", command.CommandText);
    }
    else
    {
         e.Data["Query:"] = command.CommandText;
    }
