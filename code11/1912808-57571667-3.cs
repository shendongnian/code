        var mDT = new ViewMediaTableAdapter().GetDataByPublishYear(publishYear);
        Media m = null;
        if (mDT.Count > 0)
            media = new Media(mDT[0].MediaID, mDT[0].Title, mDT[0].PublishYear);
        return m;
