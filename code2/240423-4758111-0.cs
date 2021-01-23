            var server = RegisteredTfsConnections.GetProjectCollection(new Uri("http://hostname:8080/"));
            var projects = TfsTeamProjectCollectionFactory.GetTeamProjectCollection(server);
            var versionControl = (VersionControlServer)projects.GetService(typeof(VersionControlServer));
            
            var newestDate = DateTime.MinValue;
            Item newestItem = null;
            var items = versionControl.GetItems("$/theproject/trunk/setup/*.msi");
            foreach (var item in items.Items)
            {
                if (item.ItemType != ItemType.File)
                    continue;
                if (item.CheckinDate > newestDate)
                {
                    newestItem = item;
                    newestDate = item.CheckinDate;
                }
            }
            newestItem.DownloadFile("C:\\temp\\" + Path.GetFileName(newestItem.ServerItem));
