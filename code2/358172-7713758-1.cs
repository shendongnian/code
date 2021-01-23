    [Export]
    public class DialogService
    {
        public bool? ShowDialog(string regionName, object data = null)
        {
            var window = new Window();
            var presenter = new ContentControl();
            presenter.SetProperty(RegionManager.RegionName, regionName);
            window.Content = presenter;
            if (data != null) window.DataContext = data;
            return window.ShowDialog();
        }
    }
