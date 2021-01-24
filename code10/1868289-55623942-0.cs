    private  void Button_Clicked(object sender, EventArgs e)
    {
        gobackAsync();
    }
    public async void gobackAsync() {
        int totalModals = Application.Current.MainPage.Navigation.ModalStack.Count;
        //i set currModal = 1 here to back to page 2, If you wan to go back to 3, you can set currModal = 2, etc...
        // remember to add flase in PopModalAsync to aviod the animation.
        for (int currModal = 1; currModal < totalModals; currModal++)
        {
            await Application.Current.MainPage.Navigation.PopModalAsync(false);
        }
    }
