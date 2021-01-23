    protected void SetBlueBoxVisibility(bool blueBoxVisibility)
    {
        SetGenericBoxVisibility(project => project.ShowBlueBox = blueBoxVisibility,
                                () => ShowBlueBoxPanel(blueBoxVisibility));
    }
    protected void SetRedBoxVisibility(bool redBoxVisibility)
    {
        SetGenericBoxVisibility(project => project.ShowRedBox = redBoxVisibility,
                                () => ShowRedBoxPanel(redBoxVisibility));
    }
