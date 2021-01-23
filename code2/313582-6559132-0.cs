    using (StreamReader sr = new StreamReader(response.GetResponseStream()))
    {
        String s = sr.ReadToEnd();
        System.Windows.Deployment.Current.Dispatcher.BeginInvoke(() => { MessageBox.Show(s); });
    }
