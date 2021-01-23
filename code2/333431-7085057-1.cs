    private void NewsRefresh_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            NewsRefresh.Enabled = false;
            var vm = this.DataContext as MainPageViewModel;
            if (vm != null)
            {
                vm.UpdateNews();
            }
        }
        finally
        {
            NewsRefresh.Enabled = true;
        }
    }
