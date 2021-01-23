    public IInteractionsProvider InteractionsProvider 
    { 
        get { return (IInteractionsProvider)GetValue(InteractionsProviderProperty); } 
        set {
            var oldValue = this.InteractionsProvider;
            if (oldValue != null)
                oldValue.InteractionRequested -= this.HandleInteractionRequested;
            if (newValue != null)
                newValue.InteractionRequested += this.HandleInteractionRequested;
            this.SetValue(InteractionsProviderProperty, value);
        } 
    } 
    private void HandleInteractionRequested(object sender, EventArgs e)
    {
        //...
    }
