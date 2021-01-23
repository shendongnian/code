    protected void AddNewForm(object o)
    {
        try
        {
            o.GetType().GetMethod("Show").Invoke(o, null);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }
