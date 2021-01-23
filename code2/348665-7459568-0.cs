    using (WebClient webclient = new WebClient())
    {
        using (var imageStream = webclient.OpenRead("http://example.com/image.png"))
        {
            Image img = Image.FromStream(imageStream);                   
        }
    }
