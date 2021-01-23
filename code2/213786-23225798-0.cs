    private int myVariable;
    public int myVariable 
    {
        get 
        { 
           return myVariable; 
        }
        set 
        {
            if (value < 0) 
            { 
               throw new Exception("This is your exception some where else in code");
            }
            myVariable = value; //remember value is something that is
                                //declared automatically
        }
    }
    public string FirstName { get; set; }
