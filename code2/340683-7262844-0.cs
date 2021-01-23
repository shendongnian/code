    public Image GetImage(string name) 
    {   
        var field = DM.DMresourceLib.GetType().GetField(name, BindingFlags.Public | 
                        BindingFlags.Static);             
                
        return (Image)field.GetValue(DM.DMresourceLib); 
    }
