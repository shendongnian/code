    Uri baseUri = new Uri("http://domain.is");
    Uri myUri = new Uri(baseUri, url);
    
    System.Net.WebClient client = new System.Net.WebClient();
    byte[] dl = client.DownloadData(myUri);
