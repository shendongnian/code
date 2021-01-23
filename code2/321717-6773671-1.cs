    public void Start()
    {
        try
        {
            if (this.HasNoOil)
            {
                throw new SpecificException("Can't go without oil. We'll do some damage");
            } 
            // Other stuff
        }
        catch (Exception ex)
        {
            // Log details of exception and throw it up the stack
            throw ex;
        }
    }
