    protected override async void OnAppearing(object sender, EventArgs e)
                {
                    base.ViewIsAppearing(sender, e);
        
                    UserDialogs.Instance.ShowLoading();
                    //do stuff here
                    UserDialogs.Instance.HideLoading();
                }
