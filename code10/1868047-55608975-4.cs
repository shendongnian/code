    public override async void Navigate(Page  page)
        {        
            page.BaseViewModel.SelectedPatient = BaseViewModel.SelectedPatient;
            await Navigation.PushAsync(page, true);
        }
       
