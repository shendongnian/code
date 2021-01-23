    public String script = "";
    
    protected void Page_Load(object sender, EventArgs e)
    {
        throwExcep();
    }
    
    private void throwExcep()
    {
        try
        {
            throw new NotImplementedException();
        }
        catch (Exception e)
        {
            script = "console.log('exception throws from backend message: ["+e.Message+"]')";
        }
    }
