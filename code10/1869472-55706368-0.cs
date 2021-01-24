    if(Request["year"].IsInt())
    {
        if(Request["year"].AsInt() < 0)
        {
           ...blah blah blah
        }
    }
    else
    {
        error_mes = "Please Input integer";
    }
