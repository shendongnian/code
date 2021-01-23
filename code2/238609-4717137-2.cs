    foreach (SmartEnumerable<DataRowView> item in new SmartEnumerable<DataRowView>(orderedTable.DefaultView))
    {
        DataRowView row = item.Value;
        if(item.IsLast)
        {
           ///do special stuff
        }
    }
