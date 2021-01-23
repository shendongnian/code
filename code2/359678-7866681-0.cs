    var url = @"http://server/Lists/ContentApList";
    var web = new SPSite(url).OpenWeb();
    var list = web.GetList(url);
    var item = list.GetItemById(1);
    item["MyCheck"] = "test23";
    item.ModerationInformation.Status = SPModerationStatusType.Pending;
    item.ModerationInformation.Comment = "my coment";
    item.SystemUpdate();
