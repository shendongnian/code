    private async void button_download_image_Clicked(object sender, EventArgs e)
    {
        Uri image_url_format = new Uri(image_url);
        WebClient webClient = new WebClient();
        try
        {            
            await webClient.DownloadDataAsync(image_url_format); // This will await the download
            ...
        }
        catch (Exception ex)
        {
            ...
        }
    }
