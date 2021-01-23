    public void UpdateImageTags(int imageId, IEnumerable<string> currentTags) 
    { 
        using (var db = new ImagesDataContext()) 
        { 
            var image = db.Images.Where(it => it.ImageId == imageId).First()
            image.Tags.Clear();
            foreach(string s in currentTags)
            {
                image.Tags.Add(new Tag() { TagName = s});
            } 
            db.SubmitChanges();  
        }
     }
