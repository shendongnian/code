    private void OnToggled(object sender, ToggledEventArgs e)
    {
        if(e.Value)
        {
            OneSignal.SetSubscription(true);
        }
        else
        {
            OneSignal.SetSubscription(false);
        }
    }
