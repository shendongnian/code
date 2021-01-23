    private void About_Click(object sender, EventArgs e)
        {   
            NavigationService.Navigate(new Uri("/Library;component/Pages/About.xaml", UriKind.Relative));
        }
        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            if (e.Content is About)
            {
                About page = e.Content as About;
                if (page != null)
                {
                    page.VersionString = App.VersionText;
                }
            }
            base.OnNavigatedFrom(e);
        }
