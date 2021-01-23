    try
    {
    this.Enabled = false;
    // some process
    }
    catch(Exception ex)
    {
    MessageBox.Show(ex.Message);
    }
    finally
    {
    this.Enabled = true;
    }
