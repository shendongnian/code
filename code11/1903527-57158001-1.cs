    public void SetMenuEnabled(bool enable)
    {
       foreach (var primaryButton in Menu.PrimaryButtons)
       {
          primaryButton.IsEnabled = false;
       }
       foreach (var secondaryButton in Menu.SecondaryButtons)
       {
          secondaryButton.IsEnabled = false;
       }
    }
