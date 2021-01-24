    var isParsable = DateTime.TryParse(dteCommission.SelectedDate.Value.Date.ToShortDateString(),
    out DueDate);
    if (isParsable)
    {
         //Continue With your Procedure
    }
    else
    {
         MessageBox.Show("Due Date wasn't set. Defaulting to current date.", "Alert",
         MessageBoxButton.OK, MessageBoxImage.Warning);
    }
