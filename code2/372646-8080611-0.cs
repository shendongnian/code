    try
    {
        using (var cx = new ValidationContext())
        {
            if (this) cx.AddError("Please provide a value for ...");
            if (that) cx.AddError("Please provide a value for ...");
        }
    }
    catch (Exception ex)
    {
        lblError.Text = ex.Message;
    }
