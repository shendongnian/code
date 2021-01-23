    public void ShowMe() {
        Show();
        while (!_receivedDeactivateEvent)
            Application.DoEvents();
    }
