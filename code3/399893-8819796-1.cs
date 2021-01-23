    string timeFrom = null;
    string timeTo = null;
    foreach (Control control in span_tempList.Controls)
    {
         if (control is TimePeriod)
         {
             timeFrom = ((TimePeriod)control).TimeFrom.Text;
             timeTo = ((TimePeriod)control).TimeTo.Text;
             // Do something with these values
         }
    }
