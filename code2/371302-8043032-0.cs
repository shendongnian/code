		WebBrowser browser;
		private void button1_Click(object sender, RoutedEventArgs e)
		{
			string url = @"your_really_long_url_here";
			browser = new WebBrowser();
			browser.Navigated += new EventHandler<NavigationEventArgs>(browser_Navigated);
			browser.Navigate(new Uri(url, UriKind.Absolute));
		}
		void browser_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
		{
			string htmlContent = browser.SaveToString();
			System.Diagnostics.Debug.WriteLine(htmlContent);
		}
