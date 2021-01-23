    static void UpdateMigrate(SPListItem item)
    {
      UpdateInternal(item, true, false, Guid.Empty, true, false,false, false, false, false);
    }
    static void CheckList5()
    {
        var url = @"http://server/Lists/ContentApList";
        var web = new SPSite(url).OpenWeb();
        var file = web.GetFile("CheckDocLib/logo.gif");
        var item = file.ListItemAllFields;
        item["MyComments"] = "test23ddd";
        item.ModerationInformation.Status = SPModerationStatusType.Approved;
        item.ModerationInformation.Comment = "my coment";
        UpdateMigrate(item);
    }
