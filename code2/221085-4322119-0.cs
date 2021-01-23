 protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (ListBox1.Items.Count == 0)
        {
            args.IsValid = false;
        }
        else
        {
            args.IsValid = false;
        }
    }
