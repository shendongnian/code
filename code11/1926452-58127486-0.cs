    private event EventHandler onStart = delegate { };
    protected override void OnStart() {
        onStart += handleStart; //subscribe
        onStart(this, EventArgs.Empty); //raise event
    }
    private async void handleStart(object sender,EventArgs args) {
        onStart -= handleStart; //unsubscribe
        // Initialise the application
        await Initialise();
        // Default to the Log on screen
        if (Helper.IsPortrait)
            MainPage = new LogOnPortraitPage();
        else
            MainPage = new LogOnLandscapePage();
        base.OnStart();
    }
