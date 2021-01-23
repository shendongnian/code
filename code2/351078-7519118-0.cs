    try
    {
      var item = list.GetItemById(3);
      item["MyField"] = "FooBar";
      item.Update();
    }
    catch(SPException conflictEx)
    {
      // handle conflict by re-evaluating SPListItem
      var item = list.GetItemById(3);
      // ..
    }
