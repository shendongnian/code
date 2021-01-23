    public void DeleteSelectedImages()
    {
        var picturesToRemove = panelPicturesWrapper.Controls
                                                   .Cast<SelectablePicture>();
                                                   .Where(p => p.IsSelected())
                                                   .ToList();
 
        foreach (var picture in picturesToRemove)
        {
            RemovePicture(picture);
        }
    }
