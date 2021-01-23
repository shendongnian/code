    void BusStop_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
    {       
        var bNumb = ((FrameworkElement)sender);
        if (bNumb != null)
        {
            //bNumb is of type Pushpin
            //bNumb.Tag should have your id in it, I assume it's going to be an XElement object
            string id = "Bus Number Should go here" ;
            NavigationService.Navigate(new Uri("/TestPage.xaml?stopNumber=" + id, UriKind.Relative));
            MessageBox.Show("Stop Number" + id);           
        }
    }
