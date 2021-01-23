    if (arr2.length > 0)
    {
        foreach (int i in arr2)
        {
            Device d = Device.Find(i);
            d.Projects.Add(project);
            d.SaveAndFlush();
        }
    }
