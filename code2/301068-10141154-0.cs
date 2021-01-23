    // Desired: This method uses a weak parameter type   
    public void ManipulateItems<T>(IEnumerable<T> collection) { ... }  
     
    // Undesired: This method uses a strong parameter type   
    public void ManipulateItems<T>(List<T> collection) { ... }
