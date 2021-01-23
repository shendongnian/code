    public List<string> FillOrder 
    {     
        get 
        { 
            List<string> result = Session[SessionKeys.QueryFillOrder] as List<string>;
            if (result == null)
            {
                result = new List<string>();
                Session[SessionKeys.QueryFillOrder] = result;
            }
            return result;
        }     
        set { Session[SessionKeys.QueryFillOrder] = value; } 
    } 
