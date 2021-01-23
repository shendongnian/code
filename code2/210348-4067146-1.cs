    XDocument yourDocument = new XDocument(
        new XElement("root",
            from item in yourListView.Items.AsQueryable()
            select new XElement("Child", item.SubItems.AsQueryable()Select(
                (subitem, i) => new XAttribute(yourListView.Columns[i].Text,
                    subItem.Text)))));
