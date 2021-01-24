    foreach (var item in configItemsElement)
    {
        dynamic innerItem = item.GetType().GetProperties()[1].GetValue(item);
        listOptions.Add(new InnerItemType() { 
            value = innerItem.value, 
            sortOrder = innerItem.sortOrder
        });
