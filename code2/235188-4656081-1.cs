     public static double BytesToKilobytes(this Int32 bytes)
        {
            return bytes / 1024d;
        }
    
        public static double BytesToMegabytes(this Int32 bytes)
        {
            return bytes / 1024d / 1024d;
        }
    
        public static double BytesToGigabytes(this Int32 bytes)
        {
            return bytes / 1024d / 1024d / 1024d;
        }
    
        void wc_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            if (e.Error != null)
                return;
    
            XDocument xDocument = XDocument.Parse(e.Result);
    
            listBox1.ItemsSource = from query in xDocument.Descendants("service")
                                   select new Service
                                   {
                                       type = query.Attribute("type").Value,
                                       id = query.Element("id").Value,
                                       plan = query.Element("username").Value,
                                       quota = Convert.ToInt32(query.Element("quota").Value).BytesToGigabytes(),                                   };
        }
