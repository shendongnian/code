    public static async Task SetRequestedThemeAsync(ElementTheme theme)
    {
        foreach (var view in CoreApplication.Views)
        {
            await view.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                if (Window.Current.Content is FrameworkElement frameworkElement)
                {
                    frameworkElement.RequestedTheme = theme;
                }
            });
        }
    }
