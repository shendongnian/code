        public void NavigateTo(Uri url) {
            webBrowser1.Navigate(url);
            timer1.Enabled = true;
        }
        private void timer1_Tick(object sender, EventArgs e) {
            timer1.Enabled = false;
            MessageBox.Show("Timeout on navigation");
        }
        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e) {
            if (e.Url == webBrowser1.Url && timer1.Enabled) {
                timer1.Enabled = false;
                // etc..
            }
        }
