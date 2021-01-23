      private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
            {
                HeaderedContentControl hcc = e.AddedItems[0] as HeaderedContentControl;
                if (hcc != null)
                {
                    WebBrowser webBrowser = hcc.Content as WebBrowser;
                    if (webBrowser != null)
                    {
                        // do something...
                    }
                }
            }
