    SPList _listObj = web.Lists[new Guid(listID)];
    if (_listObj != null)  // do we have a list object?
    {
        if (_listObj.Fields.Count > 0) // do we have list columns on the list?
        {
            SPListItem item = _listObj.GetItemById(Convert.ToInt32(itemID));
            if (item != null) // did our item ID get a hit?
            {
                foreach (SPField field in _listObj.Fields)
                {
                    if (field.Title != null)  // need lower case null, here
                    {  
                        //do some code
                    }
                }
            }
        }
    }
