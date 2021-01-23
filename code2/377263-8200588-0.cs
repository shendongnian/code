    try
    {
        MessageBox.Show(manager.GetAttribute("not_existing_element"));
    }
    catch (Exception ex)
    {
        MessageBox.Show(ex.Message);
    }
