    void DisableButtons()
    {
        foreach(var button in Resources.OfType<Button>())
        {
            button.IsEnabled = false;
        }
    }
