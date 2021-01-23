            MyprogressBar.IsIndeterminate = true;
            MyprogressBar.Visibility = Visibility.Visible;
            string site = MyTextBox1.Text;
            webBrowser1.Navigate(new Uri(site, UriKind.Absolute));
            webBrowser1.Navigating += webBrowser1_Navigating;
            webBrowser1.LoadCompleted += new System.Windows.Navigation.LoadCompletedEventHandler(webBrowser1_LoadCompleted);
        }
        private void webBrowser1_Navigating(object sender, NavigatingEventArgs e)
        {
            MyTextBox1.Text = e.Uri.ToString();
            MyprogressBar.IsIndeterminate = true;
            MyprogressBar.Visibility = Visibility.Visible;
        }
