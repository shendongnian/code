    try
    {
        umTableAdapter.Update(umDataSet.User);
        umDataSet.User.AcceptChanges();
    }
    catch (Exception ex)
    {
        // TableAdapter.Update() can throw exceptions
    }
