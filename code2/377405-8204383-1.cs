    webBrowser1.Navigate(listBox3.SelectedItem.ToString());
    DateTime start = DateTime.Now;
    while(webBrowser1.ReadyState != WebBrowserReadyState.Complete) {
        Application.DoEvents();
        if(webBrowser1.IsDisposed || DateTime.Now.Subtract(start).TotalSeconds > 10.0) break; // A time limit of 10 seconds, can be changed
        if(webBrowser1.ReadyState == WebBrowserReadyState.Complete) {
            MessageBox.Show("Success!");
        }
    }
