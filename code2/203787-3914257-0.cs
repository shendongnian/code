    var imageList = (
        from ic in db.ImageCats
        where ic.CatID.Contains(category)
        select new Image()
        {
             Id= ic.ImageID,
             Height = (int)ic.Height,
             Name = ic.Name,
             Width = (int)ic.Width,
        }
    ).ToList();
