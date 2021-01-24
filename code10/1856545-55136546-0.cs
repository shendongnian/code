    public INavigation Navigation { get; set;}
        public YourViewModel(INavigation navigation)
        {
            this.Navigation = navigation;
            this.YourButtonClick= new Command(async () => await GotoPage2());
        }
        public async Task GotoPage2()
        {
             /////
             await Navigation.PushAsync(new Page2());
        }
