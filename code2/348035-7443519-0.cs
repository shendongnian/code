     Dispatcher.CurrentDispatcher.Invoke(() => 
         {
           
            if (MessageBox.Show("Geen resultaat gevonden, " + errortext + ".\n Wilt u overschakelen naar handmatig? ", "Handmatig?", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                RB_handmatig.IsChecked = true;
            }
            else
            {
                //
            }
        });
