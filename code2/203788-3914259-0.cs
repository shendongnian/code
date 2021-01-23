    var imageList = db.ImageCats.Where(ic => ic.CatID.Contains(category))
    .Select(ic => new Image{ Id = ic.ImageID, 
                             Height = (int)ic.Height, 
                             Name = ic.Name, 
                             Width = (int)ic.Width})
    .ToList(); 
