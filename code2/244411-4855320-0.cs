    if (HttpContext.Current != null)
    {
        if (HttpContext.Current.Session != null)
        {
            object cell = HttpContext.Current.Session["variable"];
            if (cell != null)
            {
                return (int) cell; // Or whatever
            }
        }
    }
