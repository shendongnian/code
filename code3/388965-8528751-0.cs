     public void nameOfCotrol_PreviewKeyDown(object sender, RoutedEventArgs e)
     {
        if((e.OriginalSource as Control).Name == "NameOfControls That would be allowed to fire the event")
        {
            You're stuff to be done here
        }
        else
        {
            e.handled = true;
         }
     }
