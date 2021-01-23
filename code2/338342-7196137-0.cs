    MyObject Property
    {
        get { return property; }
        set {
                //unsubscribe always, if it's not null 
                if(property !=null)
                   property.Changed -= property_Changed;
                //assign value 
                property = value;
    
                //subscribe again, if it's not null
                if (property != null)                            
                    property.Changed += property_Changed; 
                
            }
    }
