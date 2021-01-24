        ViewMedia viewMediaSetInstance = new ViewMedia();
        ViewMedia.ViewMediaDataTable viewMediaTable = new ViewMedia.ViewMediaDataTable();
        Model.ViewMediaTableAdapters.ViewMediaTableAdapter MediaTableAdapter = new Model.ViewMediaTableAdapters.ViewMediaTableAdapter();
        MediaTableAdapter.findByPublishYear(viewMediaTable, publishYear);
        if (viewMediaTable.Count > 0)
        {
            ViewMediaRow selectedUser = viewMediaTable[0];
            media = new Media(selectedUser.MediaID, selectedUser.Title, selectedUser.PublishYear);
            return media;
        }
        else
        {
            return null;
        }
