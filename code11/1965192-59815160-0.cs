    public MyController (INavigation Navigation) {
        this.Navigation = Navigation;
    }
    public async void ClosePage () {
        await Navigation.PopAsync();
    }
