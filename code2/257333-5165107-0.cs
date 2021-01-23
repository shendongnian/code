        private void DoSomething()
        {
            webBrowser1.PreviewKeyDown += new PreviewKeyDownEventHandler(webBrowser1_PreviewKeyDown);
        }
        private void webBrowser1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.O)
            {
                menuItem.PerformClick();
                // MessageBox.Show("Done");
            }
        }
