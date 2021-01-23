    void DisableButtons()
    {
        foreach(var button in Resources.OfType<Bytton>())
        {
            button.IsEnabled = false;
        }
    }
