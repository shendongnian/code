            public static async Task NavigateAsync<TContentPage, TNavigationParameter>(INavigation navigation,
            TNavigationParameter navParam,
            Action<TContentPage, TNavigationParameter> action = null) where TContentPage : ContentPage
        {
            var contentPage = App.Container.Resolve<TContentPage>();          
            action?.Invoke(contentPage, navParam);           
            await navigation.PushAsync(contentPage, true);
        }
