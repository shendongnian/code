      private void XmlDataProvider_DataChanged(object sender, EventArgs e)
            {
                Dispatcher.BeginInvoke((Action)(() =>
                {
                    XmlDataProvider oProv = this.DataContext as XmlDataProvider;
                    oProv.Refresh();
                }));
            }
