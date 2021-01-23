    using (var webClient = new System.Net.WebClient()) {
        var json = webClient.DownloadString(URL);
        // Now parse with JSON.Net
    }
    
