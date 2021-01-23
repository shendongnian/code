    foreach (GridDataItem item in RadGrid1.Items)
        {
            if(item.ItemType == GridItemType.Item ||
                        item.ItemType ==   GridItemType.AlternatingItem)
            {
                string k = item["Id"].Text;// is empty string 
                ...
  
