        private const string apiUrl = "http://api.eveonline.com";
        public void UpdateAllianceList()
        {
            const string serviceUrl = "/eve/AllianceList.xml.aspx";
            var wc = new WebClient();
            wc.DownloadStringCompleted += (s, args) =>
                                              {
                                                  var worker = new Thread(ParseXmlThread);;
                                                  worker.Start(args.Result);
                                              };
            wc.DownloadStringAsync(new Uri(apiUrl + serviceUrl));
        }
        private void ParseXmlThread(object xml)
        {       
            // PARSING & ADDING TO THE VIEWMODEL.
        }
