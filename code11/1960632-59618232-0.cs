 using (var webClient = new WebClient())
    {
        if (!string.IsNullOrWhiteSpace(channelToken))
        {
            webClient.DefaultRequestHeaders.Authorization = 
                new AuthenticationHeaderValue("Bearer", channelToken);
        }
        webClient.DownloadFile(remoteFileUrl, localFileName);
    }
