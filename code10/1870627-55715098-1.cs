    public void myFunction(bool required, string optional) 
    {
        if(String.IsNullOrEmpty(optional))
            optional = "This is optional"
        ...
    }
