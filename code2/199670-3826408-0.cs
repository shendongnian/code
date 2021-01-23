      private WebClient webClient = new WebClient();
      try {
            Stream strm = webClient.OpenRead(URL);                                   
        }
        catch (WebException we) {
            throw we;
        }
