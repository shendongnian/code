IUpdateSearcher updateSearcher = updateSession.CreateUpdateSearcher();
ISearchResult searchResult = updateSearcher.Search("IsInstalled = 0");
var updateCollection = new UpdateCollection();
           for (int i = 0; i < searchResult.Updates.Count; i++)
            {
                IUpdate update = searchResult.Updates[i];
                //update id from registry
                if (update.Identity.UpdateID == "081cab8e-faf5-421b-be7c-3e796837f1ff")
                {
                    updateCollection.Add(update);
                    break;
                }
            }
            downloader = updateSession.CreateUpdateDownloader();
            downloader.Updates = updateCollection;
            var downloadJob = downloader.BeginDownload(new DownloadProgress(), new DownloadCompleted(), this);
            var progress = downloadJob.GetProgress();
and in `var progress` I cat get what updates now downloading and its progress
