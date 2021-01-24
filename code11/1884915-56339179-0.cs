    private void Page1_Loaded(object sender, RoutedEventArgs e)
    {
        string uri = this.NavigationService.CurrentSource.ToString();
        string querystring = uri.ToString().Substring(uri.IndexOf('?'));
        System.Collections.Specialized.NameValueCollection parameters = System.Web.HttpUtility.ParseQueryString(querystring);
        string val = parameters["IP"];
        if (!string.IsNullOrEmpty(val))
        {
            MessageBox.Show(val, "Information", MessageBoxButton.OK);
        }
    }
