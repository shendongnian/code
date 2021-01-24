        var mDT = new ViewMediaTableAdapter.getByPublishYear(publishYear);
        Media m = null;
        if (viewMediaTable.Count > 0)
            media = new Media(viewMediaTable[0].MediaID, viewMediaTable[0].Title, viewMediaTable[0].PublishYear);
        return m;
