       public static async Task NavigateAsync<TContentPage>(INavigation navigation ) where TContentPage : ContentPage
        {
            var contentPage = App.Container.Resolve<TContentPage>();          
                    
            await navigation.PushAsync(contentPage, true);
        }
