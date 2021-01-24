     private void calendar_SelectionChanged(object sender, Syncfusion.SfCalendar.XForms.SelectionChangedEventArgs e)
        {
            var dateAdded = e.DateAdded;
            var dateRemoved = e.DateRemoved;
            if (dateRemoved != null)
            {
                list = dateAdded.Except(dateRemoved).ToList();
            }
            else
            {
                list = dateAdded.ToList();
            }         
           
        }
