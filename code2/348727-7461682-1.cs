    var image = db.Images.FirstOrDefault(i => i.Id == currImageId);
    var imagesHierarchy = new List<Image>();
    if (image != null)
    {
        var parent = image.Parent;
        while (parent != null)
        {
            imagesHierarchy.Insert(0, parent);
            parent = parent.Parent;
        }
    }
    var breadcrumb = string.Join(" > ", imagesHierarchy.Select(i => i.Name));
