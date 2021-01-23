    protected override void OnInvoke(ScheduledTask task)
    {
        ShellToast popupMessage = new ShellToast()
        {
            Title = "My First Agent",
            Content = "Background Task Launched",
        };
        popupMessage.Show();
    
        UpdateTile().ContinueWith(x => NotifyComplete());
    }
    
    private Task<bool> UpdateTile()
    {
        var tcs = new TaskCompletionSource<bool>(TaskCreationOptions.AttachedToParent);
    
        WebClient twitter = new WebClient();
    
        twitter.DownloadStringCompleted += (sender, e) =>
        {
            if (e.Error != null)
            {
                tcs.TrySetResult(true);
            }
            else
            {
                XElement xmlTweets = XElement.Parse(e.Result);
    
                var message2 = xmlTweets.Descendants("status")
                                        .Select(x => x.Element("text").Value).FirstOrDefault();
    
                ShellTile appTile = ShellTile.ActiveTiles.First();
    
                if (appTile != null)
                {
                    StandardTileData tileData = new StandardTileData
                    {
                        BackContent = DateTime.Now.ToString() + message2.ToString()
                    };
    
                    appTile.Update(tileData);
    
                    tcs.TrySetResult(true);
                }
                else
                {
                    tcs.TrySetResult(true);
                }
            }
        };
    
        twitter.DownloadStringAsync(new Uri("http://api.twitter.com/1/statuses/user_timeline.xml?screen_name=dnivra26"));
    
        return tcs.Task;
    }
