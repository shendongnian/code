    private readonly HttpContextBase _context;
    public Foo(HttpContextBase context)
    {
        _context = context;
    }
    
    public void ClearSessionState()
    {
        _context.Session["VariableName"] = null;
    }
