    public partial class About : PhoneApplicationPage
    {
        public string VersionString { get; set; }
        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            versionTextBlock.Text = VersionString;
        }
    }
