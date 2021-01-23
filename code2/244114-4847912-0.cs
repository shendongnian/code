    [Test]
    public void NotifiesChangeIn_TogglePauseTooltip()
    {
       var listener = new PropertyChangeListener(_mainViewModel);
        
       _mainViewModel.TogglePauseCommand.Execute(null);
        
       Assert.That(listener.HasReceivedChangeNotificationFor("TogglePauseTooltip"));
    }
