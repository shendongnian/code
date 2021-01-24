    public class MenuPageViewModel : ViewModelBase, IPageLifecycleAware
    {
        public MenuPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            //LoadCount();
        }
    
        private async void LoadCount()
        {
            NavigationPage navigationPage = Application.Current.MainPage as NavigationPage;
            var tabbpedPage = navigationPage.Navigation.NavigationStack.FirstOrDefault();
            var count = tabbpedPage.ToolbarItems.Count;
    
            if (count > 0)
            try
            {
                var toolbarservice = DependencyService.Get<IToolbarItemBadgeService>();
        
                toolbarservice.SetBadge(tabbpedPage, tabbpedPage.ToolbarItems.FirstOrDefault(), "1", Color.Red, Color.White);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    
        public void OnAppearing()
        {
            LoadCount();
        }
    
        public void OnDisappearing()
        {
                
        }
    }
