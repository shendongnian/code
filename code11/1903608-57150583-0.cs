    private string SelectedAdvisor;
    public FavoriteButtonPopupView(string selectedAdvisor)
    {
      // store the parameter in a class level variable so other methods can access it
      SelectedAdvisor = selectedAdvisor;
      ...
    }
    private void OkayButtonClicked(object sender, EventArgs e) 
    {
    
        // do something with SelectedAdvisor here
        PopupNavigation.Instance.PopAsync();
    
        DisplayAlert("Attention", "You have successfully added Adviser to said List", "Okay"); 
    }
