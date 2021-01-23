    var id = updateNode.SelectSingleNode("./Id").InnerText;
    var val = updateNode.SelectSingleNode("./Type").InnerText;
    var query = rootPathOfItems + "//*[@@id='{" + id + "} and @Type!='" + val + "']";
    var item = Sitecore.Context.Database.SelectSingleItem(query);
    if (item != null) {
        item.Editing.BeginEdit();
        item.Fields["Type"].Value = val;
        item.Editing.EndEdit();
    }
