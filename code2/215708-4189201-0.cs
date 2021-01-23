    System.Net.WebClient client = new System.Net.WebClient();
                        
    String url = "http://stackoverflow.com/feeds/question/4188449";
    String xmlSource = client.DownloadString(url);
    Console.WriteLine(xmlSource);
