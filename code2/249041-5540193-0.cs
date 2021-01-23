    public static void MyCallback(string aString, Exception e)
    {
        Deployment.Current.Dispatcher.BeginInvoke(() =>
        {
            if (e == null)
            {
                // aString is the response from the web server
                MessageBox.Show(aString, "success", MessageBoxButton.OK);
            }
            else
            {
                MessageBox.Show(e.Message, "error", MessageBoxButton.OK);
            }
        });
    }
