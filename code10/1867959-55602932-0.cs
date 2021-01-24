     This property will contain a delegate to a method defined on the Parent Component. 
     2. Define a property and a backing variable in your Child Component:
       
 
       private string username;
    public string UserName
    {
        get => username;
        set
        {
            username = value;
            // Invoke the delegate passing it the changed value
            OnUserNameChanged?.Invoke(value);
        }
    } 
        
