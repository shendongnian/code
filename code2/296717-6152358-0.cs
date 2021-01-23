    protected void AddNewForm(dynamic o)
    {
        try
        {
            o.Show();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }
