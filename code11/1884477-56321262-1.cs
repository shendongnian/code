    void HandleButton_Click(object sender, RoutetEventArgs e)
    {
        if (sender is Button b)
        {
            if (b == VisaCreaDoc) # VisaCreaDoc is the given name of your button instace in xaml
                ViewModel.ValidateItem(InfosPosteViewModel.CREADOC);
            else if (b == VisaTravaux)
                ViewModel.ValidateItem(InfosPosteViewModel.TRAVAUX);
            else if (...) // etc.
        }
    }
