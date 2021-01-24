csharp
private async void MainCrudPage_Loaded(object sender, RoutedEventArgs e)
{
    MainPageViewModel = new TabelaWindow_ViewModel();// Sinergia.UWP.BootStrap.AppContainer.Container.Resolve<Sinergia.UWP.ViewModels.Window.TabelaWindow_ViewModel>();
    //await MainPageViewModel.LoadAsync();
    DataContext = MainPageViewModel;
    //naviView.DataContext = MainPageViewModel.NavigationVM;
    this.Bindings.Update();
}
As the `Loaded` event is always called, regardless of whether the `Page` is cached, you are effectively overwriting the cached data View Model data when you navigate back. As the page cache reuses the existing instance of `MainPage`, the `MainPageViewModel` and `DataContext` are already populated when you return to the page (you can check this by putting a breakpoint at the beginning of the `MainCrudPage_Loaded` method.
If you update your sample to the following, you will see what I mean:
csharp
private async void MainCrudPage_Loaded(object sender, RoutedEventArgs e)
{
    if (null == DataContext)
    {
        MainPageViewModel = new TabelaWindow_ViewModel();// Sinergia.UWP.BootStrap.AppContainer.Container.Resolve<Sinergia.UWP.ViewModels.Window.TabelaWindow_ViewModel>();
        //await MainPageViewModel.LoadAsync();
        DataContext = MainPageViewModel;
    }
    //naviView.DataContext = MainPageViewModel.NavigationVM;
    this.Bindings.Update();
}
I hope that helps.
