     protected override void OnAppearing()
            {
                base.OnAppearing();
    
                if ((Application.Current.MainPage as MainMasterDetailPage) != null)
                {
                    (Application.Current.MainPage as MainMasterDetailPage).IsGestureEnabled = false;
                }
                              
            }
