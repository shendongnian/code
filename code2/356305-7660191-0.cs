    try
    {
        tblCarBindingSource.Filter = filter;
    }
    catch (System.Data.EvaluateException e)
    {
        MessageBox.Show("Please enter valid values in your text fields.");
    }
