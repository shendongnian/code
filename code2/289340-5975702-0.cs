    public TControl Create<TControl>() where TControl : IControl, new()
    {
        IControl control = new TControl();
        
        // Control initialization work
    
        return control;
    }
