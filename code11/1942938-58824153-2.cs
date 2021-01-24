    var images = build.Images.Where(b => !b.IsOverride).ToList();
    foreach (SubsystemBuild img in contentsXMLObj.SubsystemBuilds.Where(img => img.BaseBuildPath != null))
    {
        foreach (var buildImage in images.Where(b => b.Name.Equals(img.BuildName))
        {
            buildImage.LocalPath = img.BaseBuildPath;
        }
    }
