     public UpdateSession updateSession;
     public ISearchResult searchResult;
     private void Form1_Load(object sender, EventArgs e)
        {
            //check for updates
            updateSession = new UpdateSession();
            searchResult = updateSession.CreateUpdateSearcher().Search("IsInstalled=0 and Type='Software' and IsHidden=0");
            //download updates
            UpdateDownloader downloader = updateSession.CreateUpdateDownloader();
            downloader.Updates = searchResult.Updates;
            downloader.Download();
            //collect all downloaded updates
            UpdateCollection updatesToInstall = new UpdateCollection();
            foreach (IUpdate update in searchResult.Updates)
            {
                if (update.IsDownloaded)
                {
                    updatesToInstall.Add(update);
                }
            }
            //install downloaded updates
            IUpdateInstaller installer = updateSession.CreateUpdateInstaller();
            installer.Updates = updatesToInstall;
            IInstallationResult installationRes = installer.Install();
        }
