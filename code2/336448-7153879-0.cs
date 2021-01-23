    private void BgwRefreshListDoWork(object sender, DoWorkEventArgs e)
    {
        List<Game> games = _mainController.RetrieveAllGames();
    	int count = 1;
        foreach (Game game in games)
        {
            string id = game.id.ToString();
            var li = new ListViewItem(id, 0);
            li.SubItems.Add(game.title);
            li.SubItems.Add(game.Genre.name);
            li.SubItems.Add(game.Publisher.name);
            li.SubItems.Add(game.Platform.name);
            li.SubItems.Add(game.CompletionType.name);
            li.SubItems.Add(game.gameNotice);
            // This is the new line you need:
            lvwGames.Invoke(new MethodInvoker(delegate { lvwGames.Items.Add(item) }));
            double dIndex = (double)(count);
            double dTotal = (double)games.Count;
            double dProgressPercentage = (dIndex / dTotal);
            int iProgressPercentage = (int)(dProgressPercentage * 100);
            count++;
            bgwRefreshList.ReportProgress(iProgressPercentage);
        }
    }
