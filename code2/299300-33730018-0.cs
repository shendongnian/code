    public virtual void ItemAdding(SPItemEventProperties properties)
    {
       // Your logic here....
       properties.Cancel = true; 
       properties.ErrorMessage = "A custom error message.";
    }
