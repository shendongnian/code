    public string MyString
    {
        get
        {
            if(instance!=null && instance1.property1.Equals("bla"))
            {
                return "bla"; 
            }
            else 
            {
                return String.Empty; 
            }
        }
    }
