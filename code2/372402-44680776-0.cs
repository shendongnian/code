    public class ParentViewModel : INavigationAware
    {
        ...
        public void OnNavigatedFrom(NavigationContext navigationContext)
                {
            var region = RegionManager.Regions["TabsRegion"];
            foreach (var view in region.Views)
                region.Remove(view);
        }
    }
