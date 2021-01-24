    void HandleButton_Click(object sender, RoutetEventArgs e)
    {
        if (sender is Button b)
        {
            if (b == VisaCreaDoc)
                ViewModel.ValidateItem(InfosPosteViewModel.CREADOC);
            else if (b == VisaTravaux)
                ViewModel.ValidateItem(InfosPosteViewModel.TRAVAUX);
            else // etc.
        }
    }
