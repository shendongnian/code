    var sorted = data.OrderBy(item => 1); // identity (stable) sort
    orderby = "Lastname asc, Firstname desc";
    foreach (var key in orderby.Split(',').Select(clause => clause.Trim()))
    {
        if (key.EndsWith(" desc"))
        {
            key = key.Substr(0, key.Length - 5);
            sorted = data.ThenByDescending(dict => dict[key]);
        } else
        {
            if (key.EndsWith(" asc")) 
            {
                key = key.Substr(0, key.Length - 4);
            }
            sorted = data.ThenBy(dict => dict[key]);
        }
    }
