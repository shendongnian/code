    public partial class MainWindow : Window
    {
        Uri currentPage;
        private void btnNavigateToPage(object sender, MouseButtonEventArgs e)
        {
            if (currentPage == null)
            {
                this.Cursor = Cursors.Wait;
                frameWorkingArea.Navigate(new Uri("/pgMyPage.xaml", UriKind.RelativeOrAbsolute));
                currentPage = frameWorkingArea.Source;
            }
            if (!currentPage.Equals("/pgMyPage.xaml"))
            {
                frameWorkingArea.Navigate(new Uri("/pgMyPage.xaml",    UriKind.RelativeOrAbsolute));
                currentPage = frameWorkingArea.Source;
            }
        }
    }
