    if (NavigationId.StartsWith("S"))
    {
        NavigationId = NavigationId.Substring(1);
        int id;
        if (int.TryParse(NavigationId,out id))
        {
            if (id > 0)
            {
            }
        }
    }
