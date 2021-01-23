    void GetTags(IEnumerable<Photo> photos)
    {
    var ids = photos.Select(p=>p.ID).ToList();
    var tagsG = (from tag in context.GetTable<Tag>() where ids.Contains(tag.PhotoID) select new {PhotoID, Name}).GroupBy(tag=>tag.PhotoID);
    foreach(ph in photos){
    ph.Tags = tagsG[ph.ID].Select(tag=>tag.Name).ToList();
    }
    }
