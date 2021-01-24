    try
    {
        if(dteCommission.SelectedDate.HasValue) 
        { 
            DateTime.TryParse(dteCommission.SelectedDate.Value.Date.ToShortDateString(),
                        out DueDate); 
        } else{
            MessageBox.Show("Due Date wasn't set. Defaulting to current date.", "Alert",
                        MessageBoxButton.OK, MessageBoxImage.Warning);
                    DueDate = DateTime.Parse(DateTime.Now.ToShortDateString());
        }
    } 
    catch(Exception e)
    {
        Log.LogError(e);
        MessageBox.Show("Unhandle error occurred please call Admin", "Alert",
                        MessageBoxButton.OK, MessageBoxImage.Warning);
    }
