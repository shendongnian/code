    public class MyViewModel : INavigationAware {
        bool INavigationAware.IsNavigationTarget(NavigationContext navigationContext)
        {
            return false;
        }
        void INavigationAware.OnNavigatedFrom(NavigationContext navigationContext)
        {
        }
        void INavigationAware.OnNavigatedTo(NavigationContext navigationContext)
        {
        }
    }
