    public static User GetUser()
    {
      WebClient req   = new WebClient();
      req.Encoding    = Encoding.UTF8;
      byte[] response = req.DownloadData(url);
      
      User instance ;
      
      using ( MemoryStream stream = new MemoryStream(buffer) )
      using ( XmlReader    reader = XmlReader.Create( stream ) )
      {
        XmlSerializer serializer = new XmlSerializer(typeof(User)) ;
        instance = (User) serializer.Deserialize( reader ) ;
      }
      
      return instance ;
    }
