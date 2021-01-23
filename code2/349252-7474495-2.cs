    var pageList = new List<string>();
    for (int i = 1; i<=pages; i++)
    {
       pageList .Add(baseurl + "&page=" + i.ToString());
    }
            // pageList  is a list of urls
            Parallel.ForEach<string>(pageList, (x) =>
            {
               try
               {
                   WebClient client = new WebClient();
                   var pagesource = client.DownloadString(page);
                   client.Dispose();
                   lock (sourcelist)
                     sourcelist.Add(pagesource);
               }
               catch (Exception)
               {
               }
           });
