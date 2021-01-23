    void SystemEvents.UserPreferenceChanged(object sender, UserPreferenceChangedEventArgs e)
    {
        // Regional settings have changed
        if (e.Category == UserPreferenceCategory.Locale)
        {
            ...
        }
    }
