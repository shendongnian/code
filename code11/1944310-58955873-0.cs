    // Declaration of the delegate
    public delegate Task SaveDelegate(Item item);
    
    // New delegate
    SaveDelegate saveDelegate = new SaveDelegate(SaveItem);
    
    // Store the delegate in the dictionary
    taskParameters.Add("CallbackFunction", saveDelegate);
