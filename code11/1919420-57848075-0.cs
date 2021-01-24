    public static class PageExtensions
    {
        public static void SetActivePage<T>(this PageBase<T> page, Type pageType) 
            where T : ViewModel
        {
            var mainWindow = page.Dependency.ServiceProvider.GetService<MainWindowViewModel>();
            mainWindow.ActivePage = $"../Pages/{pageType.Name}.xaml";
        }
    }
