    protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (Condition)
        {
            args.IsValid = false;
        }
    }
    
