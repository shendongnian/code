    ...Page_Load...
        if (!IsPostBack)
        {
            setInitialFilter();
        }
        else
        {
            HttpContext context = HttpContext.Current;
            string whereClause = (string)(context.Session["whereClause"]);
            accessRecord(whereClause); 
        }
    ...setInitialFilter()
    {
        <logic to set initial conditions>
    }
    protected void filter()//allows filter to be called in other places to get the current filter settings and load the dashboard
    {
        <logic that determines whereClause with user selected filters from a filter div>
  
        //Added the following two lines
        HttpContext context = HttpContext.Current;
        context.Session["whereClause"] = whereClause;
    
        accessRecord(whereClause)
    }
