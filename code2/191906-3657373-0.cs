    public override BindingContext get_BindingContext()
    {
        BindingContext bindingContext = base.BindingContext;
        if (bindingContext == null)
        {
            bindingContext = new BindingContext();
            this.BindingContext = bindingContext;
        }
        return bindingContext;
    }
