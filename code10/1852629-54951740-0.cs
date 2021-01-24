    private void ButtonA_Clicked(object sender, System.EventArgs e)
    {
        string key = "A";
        Navigation.PushAsync(new SearchPage(key));
    }
