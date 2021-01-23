        while (!isCancelled)
        {
            partList = new List<ClientMessage>();
            partList.AddRange(Model.LoadSearchResult());
            if (partList.Count == 0) break;
            View.GridViewtMain.BeginInvoke(new AddMessagesDelegate(AddMessagesToGrid), new object[] {partList});
        }
