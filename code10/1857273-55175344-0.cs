    foreach(Player player in lsPlayers)
    {
        btnMuteToggle.SetBinding(SimpleButton.IsCheckedProperty, new Binding("Mute")
           {
             Source = player,
             UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged,
             Mode = BindingMode.OneWayToSource
            });
    }
