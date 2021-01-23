        public bool ConnectToAPNS()
        {
            X509Certificate2Collection certs = new X509Certificate2Collection();
            // Add the Apple cert to our collection
            certs.Add(getServerCert());
            // Apple development server address
            string apsHost;
            if (getServerCert().ToString().Contains("Production"))
                apsHost = "gateway.push.apple.com";
            else
                apsHost = "gateway.sandbox.push.apple.com";
            // Create a TCP socket connection to the Apple server on port 2195
            TcpClient tcpClient = new TcpClient(apsHost, 2195);
            // Create a new SSL stream over the connection
            sslStream = new SslStream(tcpClient.GetStream());
            // Authenticate using the Apple cert
            sslStream.AuthenticateAsClient(apsHost, certs, SslProtocols.Default, false);
            //PushMessage();
            return true;
        }
        private X509Certificate getServerCert()
        {
            X509Certificate test = new X509Certificate();
            //Open the cert store on local machine
            X509Store store = new X509Store(StoreLocation.CurrentUser);
            if (store != null)
            {
                // store exists, so open it and search through the certs for the Apple Cert
                store.Open(OpenFlags.ReadOnly);
                X509Certificate2Collection certs = store.Certificates;
                if (certs.Count > 0)
                {
                    int i;
                    for (i = 0; i < certs.Count; i++)
                    {
                        X509Certificate2 cert = certs[i];
                        if (cert.FriendlyName.Contains("Apple Production Push Services: KFDLV3XL6Y:ZJPGDMQBKC"))
                        {
                            //Cert found, so return it.
                            return certs[i];
                        }
                    }
                }
                return test;
            }
            return test;
        }
        
        private static byte[] HexToData(string hexString)
        {
            if (hexString == null)
                return null;
            if (hexString.Length % 2 == 1)
                hexString = '0' + hexString; // Up to you whether to pad the first or last byte
            byte[] data = new byte[hexString.Length / 2];
            for (int i = 0; i < data.Length; i++)
                data[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
            return data;
        }
        
        public bool PushMessage(string token, string message)
        {
            String cToken = token;
            String cAlert = message;
            int iBadge = 1;
            // Ready to create the push notification
            byte[] buf = new byte[256];
            MemoryStream ms = new MemoryStream();
            BinaryWriter bw = new BinaryWriter(ms);
            bw.Write(new byte[] { 0, 0, 32 });
            byte[] deviceToken = HexToData(cToken);
            bw.Write(deviceToken);
            bw.Write((byte)0);
            // Create the APNS payload - new.caf is an audio file saved in the application bundle on the device
            string msg = "{\"aps\":{\"alert\":\"" + cAlert + "\",\"badge\":" + iBadge.ToString() + ",\"sound\":\"new.caf\"}}";
            // Write the data out to the stream
            bw.Write((byte)msg.Length);
            bw.Write(msg.ToCharArray());
            bw.Flush();
            if (sslStream != null)
            {
                sslStream.Write(ms.ToArray());
                return true;
            }
            return false;
        }
