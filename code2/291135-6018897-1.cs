    protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (Condition == true)
        {
            args.IsValid = true;
        }
        else
        {
            args.IsValid = false;
        }
    }
    
