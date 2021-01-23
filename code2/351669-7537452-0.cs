    public void BusStop_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
    {
        var item = (sender as Pushpin).Tag as TransitVariables;
        if (item != null)
        {
            string id = item.name;
            
           NavigationService.Navigate(new Uri("/DepBoard.xaml?ListingId=" + id, UriKind.Relative));
           MessageBox.Show("Bus Stop Number " + id);
            
        }
    }
