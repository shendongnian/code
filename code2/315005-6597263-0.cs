        public bool sendTileUpdate(string tileText, string url, string image)
        {
            string TilePushXML = "<?xml version=\"1.0\" encoding=\"utf-8\"?>" +
                    "<wp:Notification xmlns:wp=\"WPNotification\">" +
                    "<wp:Tile>" +
                    "<wp:BackgroundImage>{2}</wp:BackgroundImage>" +
                    "<wp:Count>{0}</wp:Count>" +
                    "<wp:Title>{1}</wp:Title>" +
                    "</wp:Tile>" +
                    "</wp:Notification>";
            try
            {
                HttpWebRequest sendNotificationRequest = (HttpWebRequest)WebRequest.Create(url);
                sendNotificationRequest.Method = "POST";
                sendNotificationRequest.Headers = new WebHeaderCollection();
                sendNotificationRequest.ContentType = "text/xml";
                // Tile
                sendNotificationRequest.Headers.Add("X-WindowsPhone-Target", "token");
                sendNotificationRequest.Headers.Add("X-NotificationClass", "1");
                string str = string.Format(TilePushXML, "", tileText, image);
                byte[] strBytes = new UTF8Encoding().GetBytes(str);
                sendNotificationRequest.ContentLength = strBytes.Length;
                using (Stream requestStream = sendNotificationRequest.GetRequestStream())
                {
                    requestStream.Write(strBytes, 0, strBytes.Length);
                }
                HttpWebResponse response = (HttpWebResponse)sendNotificationRequest.GetResponse();
                string notificationStatus = response.Headers["X-NotificationStatus"];
                string deviceConnectionStatus = response.Headers["X-DeviceConnectionStatus"];
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
