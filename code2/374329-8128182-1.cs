    // this method downloads the feed without blocking the UI;
    // when finished it calls the given action
    public void GetFeed(Action<string> doSomethingWithFeed)
    {
        HttpWebRequest request = HttpWebRequest.CreateHttp("http://earthquake.usgs.gov/eqcenter/recenteqsww/catalogs/eqs7day-M2.5.xml");
        request.BeginGetResponse(
            asyncCallback =>
            {
                string data = null;
                using (WebResponse response = request.EndGetResponse(asyncCallback))
                {
                    using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                    {
                        data = reader.ReadToEnd();
                    }
                }
                Deployment.Current.Dispatcher.BeginInvoke(() => doSomethingWithFeed(data));
            }
            , null);
    }
    // this method will be called by GetFeed once the feed has been downloaded
    private void handleFeed(string feedString)
    {
        // build XML DOM from feed string
        XDocument doc = XDocument.Parse(feedString);
        // show title of feed in TextBlock
        textBlock1.Text = doc.Element("rss").Element("channel").Element("title").Value;
        // add each feed item to a ListBox
        foreach (var item in doc.Descendants("item"))
        {
            listBox1.Items.Add(item.Element("title").Value);
        }
        // continue here...
    }
    // user clicks a button -> start feed download
    private void button1_Click(object sender, RoutedEventArgs e)
    {
        GetFeed(handleFeed);
    }
