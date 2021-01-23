    Project project = new Project();
    project.Load(fullPathName);
    var embeddedResources =
        from grp in project.ItemGroups.Cast<BuildItemGroup>()
        from item in grp.ToArray()
        where item.Name = "EmbeddedResource"
        select item;
    foreach(BuildItem item in embeddedREsources)
    {
        Console.WriteLine(item.Include); // prints the name of the resource file
    }
