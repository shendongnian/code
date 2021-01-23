    public bool CreatePicasaAlbum(GoogleUtility.Picasa.AlbumEntry.entry a, IGoogleOauth2AccessToken token)
        {
    
    
            TcpClient client = new TcpClient(picasaweb.google.com, 443);
            Stream netStream = client.GetStream();
            SslStream sslStream = new SslStream(netStream);
            sslStream.AuthenticateAsClient(picasaweb.google.com);
    
            byte[] contentAsBytes = Encoding.ASCII.GetBytes(a.toXmlPostString());
            string data = a.toXmlPostString();
    
            StringBuilder msg = new StringBuilder();
            msg.AppendLine("POST /data/feed/api/user/default HTTP/1.1");
            msg.AppendLine("Host: picasaweb.google.com");
            msg.AppendLine("Gdata-version: 2");
            msg.AppendLine("Content-Length: " + data.Length);
            msg.AppendLine("Content-Type: application/atom+xml");
            msg.AppendLine(string.Format(GetUserInfoDataString(), token.access_token));
            msg.AppendLine("");
    
            byte[] headerAsBytes = Encoding.ASCII.GetBytes(msg.ToString());
            sslStream.Write(headerAsBytes);
            sslStream.Write(contentAsBytes);
    
            StreamReader reader = new StreamReader(sslStream);
            bool success = false;
            string albumID = "";
            while (reader.Peek() > 0)
            {  
                string line = reader.ReadLine();
                if (line.Contains("HTTP/1.1 201 Created")) { success = true; }
                if (line.Contains("Location: https") && string.IsNullOrWhiteSpace(albumID))
                {
                    var aiIndex = line.LastIndexOf("/");
                    albumID = line.Substring(aiIndex + 1);
                }
                System.Diagnostics.Debug.WriteLine(line);
                if (line == null) break;
            }
            return success;
        }
    /// <summary>
    /// User Info Data String for Authorization on TCP requests
    /// [Authorization: OAuth {0}"]
    /// </summary>
    /// <returns></returns>
    private string GetUserInfoDataString()
    {
        return "Authorization: OAuth {0}";
    }
