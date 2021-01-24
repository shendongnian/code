    DateTime DueDate;
    try
    {
         var DueDate = DateTime.TryParse(dteCommission.SelectedDate.Value.ToString());
    
    }
    catch (Exception E)
    {
         MessageBox.Show("Due Date wasn't set. Defaulting to current date.", "Alert",
         MessageBoxButton.OK, MessageBoxImage.Warning);
         //also you can you the exception type to make it clear for use if it is
         // an exception of Null, Format or Argument
    }
