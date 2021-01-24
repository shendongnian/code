      static void Main(string[] args)
        {
    
            Console.Title = "Start client first";
    
            AnnouncementService annsvc = new AnnouncementService();
            annsvc.OnlineAnnouncementReceived += OnlineRec;
            annsvc.OfflineAnnouncementReceived += OfflineRec;
            using (ServiceHost host = new ServiceHost(annsvc))
            {
                host.AddServiceEndpoint(new UdpAnnouncementEndpoint());
                host.Open();
                Console.Read();
            }
        }
    
        private static void OfflineRec(object sender, AnnouncementEventArgs e)
        {
            Console.WriteLine($"\nService is offline, service address：{e.EndpointDiscoveryMetadata.Address.Uri}");
        }
    
        private static void OnlineRec(object sender, AnnouncementEventArgs e)
        {
            Console.WriteLine($"\nService is online, service address：{e.EndpointDiscoveryMetadata.Address.Uri}");
        }
