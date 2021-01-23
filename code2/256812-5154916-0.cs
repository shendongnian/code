    public object FindObject(object OBJ, string PropName)      
    {          
        PropertyInfo[] pi = OBJ.GetType().GetProperties();           
    
        for (int i = 0; i < pi.Length; i++)           
        {               
            if (pi[i].Name == PropName)                   
            {
                return pi[i].GetValue(OBJ, null);
            }
        }            
    
        return new object();       
    }   
