    private void forecastReader_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs dc)
        {
            if (dc.Error != null)
            {
                return;
            }
            XElement xmlNews = XElement.Parse(dc.Result);
            listBox1.ItemsSource = from item in xmlNews.Descendants("parent").Elements("sub")
                                   select new ForecastItem
                                   {
                                       a = item.Element("node").Value,
                                       b = item.Element("title").Value,                                       
                                   };
        }
