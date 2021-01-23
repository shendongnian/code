    void DisableButtons()
    {
        foreach(var button in this.Resources.OfType<Bytton>())
        {
            button.IsEnabled = false;
        }
    }
