    protected void AddNewForm(object o)
    {
        try
        {
            o.GetType().GetMethod("Show", new Type[0]).Invoke(o, null);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }
