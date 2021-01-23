        // ...
        // get the created entry
        Web web = context.Web;
        List list = web.Lists.GetByTitle(libraryName);
        ListItemCollection itemCol = list.GetItems(new CamlQuery() { ViewXml = "<View/>" });
        context.Load(itemCol,
            items => items
                .Include(i => i[COLUMN_IMPORTORDERNUMBER])
                .Where(i => (string)i[COLUMN_FILELEAFREF] == filename)
                .Take(1)
                );
        context.ExecuteQuery();
        // ... found it? ...
        if (itemCol != null && itemCol.Count > 0)
        {
            ListItem item = itemCol[0];
            // ... set the ImportOrderNumber
            item[COLUMN_IMPORTORDERNUMBER] = orderNumber;
            item.Update();
            // ... and check in
            item.File.CheckIn("Checked in by WebService", CheckinType.MajorCheckIn);
            context.ExecuteQuery();
        }
    }
