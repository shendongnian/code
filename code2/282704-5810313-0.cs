    var query =
        from list in db.Lists
        where list.ProfileID == ID
        join item in db.Items on list.ID equals item.ListID into listItems
        //orderby list.CreateDate descending
        join photo in db.ItemPhotos
            on listItems.Min(c=>c.ListID) equals photo.ItemID into listPhotos
    
        select new TList.General_ListViewModel
        {
            CategoryID = list.CategoryID,
            CreateDate = list.CreateDate,
            Header = list.Header,
            FirstImageURL = listPhotos.Min(c=>c.FileName),
        };
