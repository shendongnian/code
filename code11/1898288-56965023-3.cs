    public View mView;
    
    public override void SetupDialog(Dialog dialog, int style)
    {
        base.SetupDialog(dialog, style);
        this.EnsureBindingContextIsSet(); // This is required to use this.BindingInflate()
        mView = this.BindingInflate(LayoutResourceId, null);
        dialog.SetContentView(view);
            ...        
    }
